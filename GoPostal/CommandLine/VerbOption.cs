using Mono.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoPostal.CommandLine
{
    public class VerbOption
    {
        public static Verb? Selected = null;

        public static void Parse(string[] args)
        {
            var commandLineOptions = new OptionSet();

            foreach (var item in parameterDictionary)
            {
                commandLineOptions.Add(item.Key, v => SetSelection(item.Value));
            }

            commandLineOptions.Parse(args);
        }

        private static void SetSelection(Verb selection)
        {
            Selected = Selected == null 
                ? Selected = selection 
                : throw new ArgumentException($"Attempted to set a verb of {selection} when {Selected} was already selected.");
        }

        private static Dictionary<string, Verb> parameterDictionary = new Dictionary<string, Verb>
        {
            { "g|get", Verb.Get },
            { "d|delete", Verb.Delete },
            { "p|post", Verb.Post },
            { "u|put", Verb.Put },
        };
    }

    public enum Verb
    {
        Get,
        Post,
        Put,
        Delete,
    }
}
