using Mono.Options;
using System.Collections.Generic;
using System.ComponentModel;

namespace GoPostal.CommandLine
{
    [DefaultProperty("Enabled")]
    public static class Flags
    {
        private static List<Flag> AllEnabledFlags;

        public static void Parse(string[] args)
        {
            AllEnabledFlags = new List<Flag>();

            var commandLineOptions = new OptionSet();

            foreach(var item in parameterDictionary)
            {
                commandLineOptions.Add(item.Key, v => AllEnabledFlags.Add(item.Value));
            }

            commandLineOptions.Parse(args);
        }

        public static bool Enabled(Flag flag)
        {
            return AllEnabledFlags.Contains(flag);
        }

        private static Dictionary<string, Flag> parameterDictionary = new Dictionary<string, Flag>
        {
            { "test", Flag.GoogleTest },
            { "d|displaybody", Flag.DisplayResponseBody },
            { "s|save", Flag.SaveResponseBodyToFile }
        };

        public static bool IsEnabled(this Flag flag)
        {
            return AllEnabledFlags.Contains(flag);
        }
    }

    public enum Flag
    {
        GoogleTest,
        DisplayResponseBody,
        SaveResponseBodyToFile
    }
}
