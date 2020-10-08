using TechTalk.SpecFlow;
using BBCAndLoremIpsumTest.PagesLoremIpsum;
using NUnit.Framework;

namespace BBCAndLoremIpsumTest.Steps
{
    [Binding]
    public class ContainsWordsSteps
    {
        private ScenarioContext _scenarioContext;
        public ContainsWordsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

        }

        [Given(@"the expected word in first paragraph '(.*)'")]
        public void GivenTheExpectedWordInFirstParagraph(string word)
        {
            _scenarioContext["ExpectedWordInFirstParagraph"] = word;
        }
        
        [When(@"user goes to Russian Lorem Ipsum Page")]
        public void WhenUserGoesToRussianLoremIpsumPage()
        {
            Page.GetPages<Home>().ClickLinkRussianLanguage();
        }
        
        [Then(@"the first paragraph contains the expected word")]
        public void ThenTheFirstParagraphContainsTheExpectedWord()
        {
            Assert.IsTrue(Page.GetPages<Home>().TextOfTheFirstParagraph.Contains(_scenarioContext["ExpectedWordInFirstParagraph"].ToString()));
        }
    }
}
