using TechTalk.SpecFlow;
using System.Collections.Generic;
using BBCAndLoremIpsumTest.PagesBBC;
using NUnit.Framework;

namespace BBCAndLoremIpsumTest.Steps
{
    [Binding]
    public class TextOfArticlesSteps
    {
        private ScenarioContext _scenarioContext;
        public TextOfArticlesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

        }

        [Given(@"the expected name of the headline article is '(.*)'")]
        public void GivenTheExpectedNameOfTheHeadlineArticleIs(string expectedHeadline)
        {
            _scenarioContext["ExpectedTextOfHeadlineArticle"] = expectedHeadline;
        }

        [When(@"user goes to the News page")]
        public void WhenUserGoesToTheNewsPage()
        {
            Page.GetPages<Home>().ClickNewsButton();
            Page.GetPages<Base>().ClickExitSignInFormButton();
        }

        [Then(@"the name of the headline article should match the expected name")]
        public void ThenTheNameOfTheHeadlineArticleShouldMatchTheExpectedName()
        {
            Assert.AreEqual(Page.GetPages<News>().TextOfHeadlineOfMainArticle, _scenarioContext["ExpectedTextOfHeadlineArticle"]);
        }


        [Given(@"the expected text of second articles")]
        public void GivenTheExpectedTextOfSecondArticles(Table table)
        {
            List<string> expectedSecondaryArticles = new List<string>(5);

            foreach (var tableRow in table.Rows)
            {
                expectedSecondaryArticles.Add(tableRow["titles"]);
            }
            _scenarioContext.Add("ExpectedSecondaryArticles", expectedSecondaryArticles);
        }

        [Then(@"the names of the secondary articles should match the expected names")]
        public void ThenTheNamesOfTheSecondaryArticlesShouldMatchTheExpectedNames()
        {
            List<string> list = _scenarioContext["ExpectedSecondaryArticles"] as List<string>;
            Assert.AreEqual(list.Count, Page.GetPages<News>().TextOfSecondaryArticlesTitles.Count);
            for (int i = 0; i < Page.GetPages<News>().TextOfSecondaryArticlesTitles.Count; i++)
            {
                Assert.AreEqual(Page.GetPages<News>().TextOfSecondaryArticlesTitles[i], list[i]);
            }
        }
    }
}
