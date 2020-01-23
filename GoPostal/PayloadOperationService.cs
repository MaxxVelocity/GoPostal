using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GoPostal
{
    public class PayloadOperationService
    {
        public async Task<OperationResult<string>> LoadFromFile(string path)
        {
            try
            {
                var response = await File.ReadAllTextAsync(path);
                return OperationResult<string>.Success(response);
            }
            catch(Exception ex)
            {
                return OperationResult<string>.Failure(ex.Message);
            }            
        }
    }
}
