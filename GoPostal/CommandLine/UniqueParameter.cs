using Mono.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoPostal.CommandLine
{
    public static class UniqueParamterFactory
    {
        public static T Create<T>(string parameter, string[] args) where T : IParameterValue, new()
        {
            string value = null;

            var commandLineOptions = new OptionSet();

            commandLineOptions.Add($"{parameter}=", v => value = v);

            commandLineOptions.Parse(args);

            return new T { value = value };
        }
    }
}
