using Mono.Options;
using System;
using System.Collections.Generic;

namespace GoPostal.ComandLine
{
    public class MutuallyExclusiveOptionFactory<T> where T: Enum
    {
        public static T Create(Dictionary<string, T> dictionary, string[] args)
        {
            object selection = null;

            var commandLineOptions = new OptionSet();

            foreach (var item in dictionary)
            {
                commandLineOptions.Add(item.Key, v =>
                    selection = selection == null
                        ? selection = item.Value
                        : throw new ArgumentException($"More than one option of type {nameof(T)} was specified.")
                );
            }

            commandLineOptions.Parse(args);

            return (T)selection;
        }
    }
}
