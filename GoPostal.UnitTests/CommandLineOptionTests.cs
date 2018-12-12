using GoPostal.CommandLine;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoPostal.UnitTests
{
    public class CommandLineOptionTests
    {
        [Fact]
        public void FlagsAreParsed()
        {
            CommandLine.Flags.Parse(new string[] { "-ggl" });

            Assert.True(Flag.GoogleTest.IsEnabled());
        }
    }
}
