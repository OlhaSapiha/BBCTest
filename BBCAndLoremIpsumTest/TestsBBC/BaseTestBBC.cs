using NUnit.Framework;
using System.Configuration;

namespace BBCAndLoremIpsumTest.TestsBBC
{
    [TestFixture]
    public class BaseTestBBC
    {
        private static readonly string _bbcURL = "https://www.bbc.com";
        //private static readonly string _bbcURL = ConfigurationManager.AppSettings["START_URL"];

        [SetUp]
        public void StartBrowser() => Browser.Init(_bbcURL);

        [TearDown]
        public void CloseBrowser() => Browser.Close();
    }
}
