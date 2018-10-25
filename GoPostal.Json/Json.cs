using Newtonsoft.Json;
using System;
using System.IO;

namespace GoPostal.Json
{
    public class JsonOperation
    {
        public static OperationResponse<T> HydrateFromFile<T>(string filename) where T : new()
        {
            if (!File.Exists(filename))
            {
                return OperationResponse<T>.Fail("A valid file name was not provided.");
            }

            T result;
            try
            {
                var fileContent = File.ReadAllText(@filename);
                result = JsonConvert.DeserializeObject<T>(fileContent);
            }
            catch (Exception ex)
            {
                return OperationResponse<T>.Fail(ex.Message);
            }
             

            return OperationResponse<T>.Success(result);

            //if (!File.Exists(filename))
            //{
            //    throw new FileNotFoundException("A valid file name was not provided.");
            //}

            //var fileContents = File.ReadAllText(filename);

            //if (string.IsNullOrEmpty(fileContents)) { return default(T); }

            //var x = new JsonSerializer();

            //x.Deserialize<T>()

            //throw new NotImplementedException();
        }
    }
}
