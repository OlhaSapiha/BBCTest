using NUnit.Framework;

namespace BBCAndLoremIpsumTest.TestsLoremIpsum
{
    public class BaseTestLoremIpsum
    {
        private static readonly string _loremIpsumURL = "https://www.lipsum.com/";

        [SetUp]
        public void StartBrowser() => Browser.Init(_loremIpsumURL);

        [OneTimeTearDown]
        public void CloseBrowser() => Browser.Close();
    }
}
