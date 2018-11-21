using Mono.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GoPostal
{
    [DefaultProperty("Enabled")]
    public static class CommandLineFlags
    {
        private static List<Flag> All;

        public static void Parse(string[] args)
        {
            All = new List<Flag>();

            var commandLineOptions = new OptionSet
            {
                { "ggl|google" , v => All.Add(Flag.GoogleTest) },
            };

            commandLineOptions.Parse(args);
        }

        public static bool Enabled(Flag flag)
        {
            return (All.Contains(flag));
        }

        public enum Flag
        {
            GoogleTest
        }

        private static Dictionary<string, Flag> parameterDictionary = new Dictionary<string, Flag>
        {
            { "ggl|google", Flag.GoogleTest }
        };
    }
}
