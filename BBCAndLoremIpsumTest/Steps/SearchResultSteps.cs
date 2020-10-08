using BBCAndLoremIpsumTest.PagesBBC;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BBCAndLoremIpsumTest.Steps
{
    [Binding]
    public class SearchResultSteps
    {
        private ScenarioContext _scenarioContext;
        public SearchResultSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

        }

        [Given(@"the expected text of the first article after search '(.*)'")]
        public void GivenTheExpectedTextOfTheFirstArticleAfterSearch(string expectedText)
        {
            _scenarioContext["ExpectedFirstArticleFromSearch"] = expectedText;
        }

        [When(@"user searches by category link from the first article")]
        public void WhenUserSearchesForCategoryLinkFromTheFirstArticle()
        {
            Page.GetPages<News>().SearchByKeywordUsingEnter(Page.GetPages<News>().TextOfCategoryLinkFromHeadlineArticle);
        }

        [Then(@"the name of the first article after search should match the expected name")]
        public void ThenTheNameOfTheFirstArticleAfterSearchShouldMatchTheExpectedName()
        {
            Assert.AreEqual(Page.GetPages<Search>().TextOfFirstHeadline, _scenarioContext["ExpectedFirstArticleFromSearch"]);
        }
    }
}
