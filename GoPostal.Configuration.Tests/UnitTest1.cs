using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static System.FormattableString;

namespace GoPostal.Configuration.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateUrl()
        {
            FormattableString stuff = $"http://{0}/{1}";

            WebRoute.ValidateParameters(
                stuff, 
                new System.Collections.Generic.Dictionary<string, string>
                    {
                        {"resource", "foo"},
                        {"id", "bar"},
                    }
                );
        }
    }
}
