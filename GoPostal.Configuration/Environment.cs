namespace GoPostal.Configuration
{
    public class Environment
    {
        public string BaseUrl { get; }

        public Environment(string baseUrl)
        {
            this.BaseUrl = baseUrl;
        }
    }
}
