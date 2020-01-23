using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace GoPostal.UnitTests
{
    public class MutuallyExclusiveOptionTests
    {
        [Fact]
        public void NoBleeding()
        {
            //CommandLine.VerbOptionX.Initialize(new string[] { "-get", "-ggl" });

            CommandLine.VerbOptionX.Initialize(new string[] { "-get", "-oo" });

            Assert.True(CommandLine.VerbOptionX.Selected == HttpMethod.Get);

            //CommandLine.VerbOptionY.Initialize(new string[] { "-put", "-ggl" });

            //Assert.True(CommandLine.VerbOptionY.Selected == HttpMethod.Put);

            Assert.True(CommandLine.VerbOptionX.Selected == HttpMethod.Get);
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
