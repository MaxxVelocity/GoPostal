namespace GoPostal.Json.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class JsonOperationTests
    {
        [TestMethod]
        public void HydrateFromFile_Success()
        {
            var result = JsonOperation.HydrateFromFile<SampleObject>("sample.json");

            Assert.IsNotNull(result);
            result.ShouldBeSuccessful();
            Assert.AreEqual("sampleValue", result.Value.SampleKey);
        }
    }

    public static class OperationResultExtensions
    {
        public static void ShouldBeSuccessful<T>(this OperationResponse<T> operationResponse) where T : new()
        {
            Assert.IsTrue(operationResponse.Successful, operationResponse.Message);
        }
    }
}
