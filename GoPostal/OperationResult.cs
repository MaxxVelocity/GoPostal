namespace GoPostal
{
    public class OperationResult<T> : OperationResponse
    {
        protected T content { get; }

        protected OperationResult(bool succeeded, T content, string exceptionMessage = null) 
            : base(succeeded,  exceptionMessage)
        {
            this.content = content;
        }

        protected OperationResult(bool succeeded, string exceptionMessage = null)
            : base(succeeded, exceptionMessage)
        {
        }

        public static OperationResult<T> Success(T content)
        {
            var instance = new OperationResult<T>(true, content);

            return instance;
        }

        public new static OperationResult<T> Failure(string exceptionMessage)
        {
            var instance = new OperationResult<T>(false, exceptionMessage);

            return instance;
        }
    }
}
