using TechTalk.SpecFlow;

namespace BBCAndLoremIpsumTest.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private static readonly string _bbcURL = "https://www.bbc.com";
        private static readonly string _loremIpsumURL = "https://www.lipsum.com/";

        //[BeforeScenario(Order = 1)]
        //public void StartBrowserBBC()
        //{
        //    Browser.Init(_bbcURL);
        //}

        [BeforeScenario(Order = 2)]
        public void StartBrowserLoremIpsum()
        {
            Browser.Init(_loremIpsumURL);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Browser.Close();
        }
    }
}
