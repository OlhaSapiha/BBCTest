using System;
using TechTalk.SpecFlow;
using BBCAndLoremIpsumTest.PagesLoremIpsum;

namespace BBCAndLoremIpsumTest.Steps
{
    [Binding]
    public class GenerateLoremIpsumSteps
    {
        private ScenarioContext _scenarioContext;
        public GenerateLoremIpsumSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

        }

        [Given(@"the expected start of the paragraph '(.*)'")]
        public void GivenTheExpectedStartOfTheParagraph(string start)
        {
            _scenarioContext["ExpectedStartOfParagraph"] = start;
        }
        
        [Given(@"the expected (.*) of words after generation")]
        public void GivenTheExpectedOfWordsAfterGeneration(string p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"user goes to Generate Page")]
        public void WhenUserGoesToGeneratePage()
        {
            Page.GetPages<Home>().CLickGenerateLoremIpsumButton();
        }
        
        [When(@"user generate with radio button '(.*)' and given amount")]
        public void WhenUserGenerateWithRadioButtonAndGivenAmount(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"user goes to Generate Page")]
        public void WhenUserGoesToGenerateLoremIpsumPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the paragraph starts with the expected sentence")]
        public void ThenTheParagraphStartsWithTheExpectedSentence()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the expected amount of words is displayed")]
        public void ThenTheExpectedAmountOfWordsIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
