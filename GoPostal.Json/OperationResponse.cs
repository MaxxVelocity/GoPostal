using System;

namespace GoPostal
{
    public class OperationResponse<T> where T : new()
    {
        public bool Successful { get; }

        public bool Failure { get => !Successful; }

        public T Value { get; }

        public string Message { get; }

        public static OperationResponse<T> Success(T value)
        {
            return new OperationResponse<T>
            (
                success: true,
                value: value
            );
        }

        public static OperationResponse<T> Fail(string message)
        {
            return new OperationResponse<T>
            (
                success: true,
                message: message
            );
        }

        private OperationResponse(bool success, T value = default(T), string message = null)
        {
            this.Successful = success;
            this.Value = value;
            this.Message = message;
        }
    }
}
