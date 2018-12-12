using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoPostal.UnitTests
{
    public class UniqueParameterTests
    {
        [Fact]
        public void CanParseUrl()
        {
            CommandLine.Url.Initialize(new string[] { "-url:HiMom" });

            Assert.Equal("HiMom", CommandLine.Url.Value);
        }

        [Fact]
        public void CanParseContentTypeHeader()
        {
            CommandLine.HeaderContentType.Initialize(new string[] { "-ct:SomeContentType" });

            Assert.Equal("SomeContentType", CommandLine.HeaderContentType.Value);
        }
    }
}
