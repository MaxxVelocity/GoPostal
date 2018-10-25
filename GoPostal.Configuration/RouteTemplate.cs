using System;
using System.Collections.Generic;
using System.Linq;

namespace GoPostal.Configuration
{
    public class WebRoute
    {
        public string Value { get; }

        public WebRoute(string urlTemplate, Dictionary<string,string> urlParameterCollection)
        {
            
        }

        public static void ValidateParameters(FormattableString urlTemplate, Dictionary<string, string> urlParameterCollection)
        {
            foreach(var arg in urlTemplate.GetArguments())
            {
                if(!urlParameterCollection.Any( w => w.Key == arg))
                {
                    throw new ArgumentException($"There was no matching parameter provided for the {arg} placeholder in the url template.");
                }
            }
        }
    }
}
