using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoPostal.UnitTests
{
    public class MutuallyExclusiveOptionTests
    {
        [Fact]
        public void NoBleeding()
        {
            CommandLine.VerbOptionX.Initialize(new string[] { "-get", "-noise" });

            Assert.True(CommandLine.VerbOptionX.Selected == CommandLine.Verb.Get);

            CommandLine.VerbOptionY.Initialize(new string[] { "-put", "-noise" });

            Assert.True(CommandLine.VerbOptionY.Selected == CommandLine.Verb.Put);

            Assert.True(CommandLine.VerbOptionX.Selected == CommandLine.Verb.Get);
        }

        [Fact]
        public void VerbsXAreMutuallyExclusive()
        {
            Assert.Throws<ArgumentException>(() =>               
                CommandLine.VerbOptionX.Initialize(new string[] { "-get", "-put" })
            );
        }

        [Fact]
        public void VerbsAreMutuallyExclusive()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                CommandLine.VerbOption.Parse(new string[] { "-get", "-put" });
            });
        }
    }
}
