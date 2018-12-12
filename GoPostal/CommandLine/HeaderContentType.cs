using System;
using System.Collections.Generic;
using System.Text;

namespace GoPostal.CommandLine
{
    public class HeaderContentType : IParameterValue
    {
        public static string Value { get => valueInstance.value; }

        private static HeaderContentType valueInstance;

        public static void Initialize(string[] args)
        {
            valueInstance = UniqueParamterFactory.Create<HeaderContentType>("contentType|contenttype|ct", args);
        }
    }
}
