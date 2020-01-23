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
            CommandLine.Url.Initialize(new string[] { "-Url:HiMom" });

            Assert.Equal("HiMom", CommandLine.Url.Value);
        }

        [Fact]
        public void CanParseContentTypeHeader()
        {
            var contentTypeValue = "SomeContentType";

            CommandLine.HeaderContentType.Initialize(new string[] { $"-ct:{contentTypeValue}" });

            Assert.Equal(contentTypeValue, CommandLine.HeaderContentType.Value);
        }
    }
}
