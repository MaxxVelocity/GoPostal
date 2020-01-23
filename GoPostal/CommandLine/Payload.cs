using System;
using System.Collections.Generic;
using System.Text;

namespace GoPostal.CommandLine
{
    public class Payload : IParameterValue
    {
        public static bool IsPopulated => instance?.value != null;

        public static string Value => instance.value;

        private static Payload instance;

        public static void Initialize(string[] args)
        {
            instance = instance == null
                ? UniqueParamterFactory.Create<Payload>("P|Payload", args)
                : throw new ArgumentException("There can be only one Payload specification.");
        }
    }
}
