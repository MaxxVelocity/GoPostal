using System;
using System.Collections.Generic;
using System.Text;

namespace GoPostal
{
    public class OperationResponse
    {
        public bool Succeeded { get; }

        public string ExceptionMessage { get; }

        protected OperationResponse(
            bool succeeded,
            string exceptionMessage)
        {
            this.Succeeded = succeeded;
            this.ExceptionMessage = exceptionMessage;
        }

        public static OperationResponse Success()
        {
            var instance = new OperationResponse(true, string.Empty);

            return instance;
        }

        public static OperationResponse Failure(string message)
        {
            var instance = new OperationResponse(false, message);

            return instance;
        }
    }
}
