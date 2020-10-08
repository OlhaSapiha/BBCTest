using NUnit.Framework;
using System.Collections.Generic;
using BBCAndLoremIpsumTest.BusinessLogicLayerBBC;

namespace BBCAndLoremIpsumTest.TestsBBC
{
    [TestFixture]
    public class TitlesOfArticlesBBCTests : BaseTestBBC
    {
        private static readonly List<string> _expectedSecondaryArticles = new List<string>(5)
            {
                "NY black man killed in police 'spit hood' restraint",
                "Dwayne 'The Rock' Johnson and family had Covid-19",
                "Russian opposition leader 'poisoned with Novichok'",
                "'I'm gonna go finish feeding my daughter'",
                "Australia 'anti-lockdown' arrest stirs controversy"
            };

        [Test]
        [TestCase("Biden calls for police to be charged in shootings")]
        public void CheckTheNameOfTheHeadlineArticle(string expectedHeadlineArticle)
        {
            BusinessLogicLayer BLL = new BusinessLogicLayer();
            BLL.GoToNewsPageAndCloseSignInWindow();
            BLL.CheckTextOfHeadlineArticleEqualExpectedText(expectedHeadlineArticle);
        }

        [Test]
        public void CheckSecondaryArticleTitles()
        {
            BusinessLogicLayer BLL = new BusinessLogicLayer();
            BLL.GoToNewsPageAndCloseSignInWindow();
            BLL.CheckNumberOfSecondaryArticlesEqualExpectedNumber(_expectedSecondaryArticles);
            BLL.CheckTextOfSecondaryArticlesEqualExpectedText(_expectedSecondaryArticles);
        }

        [Test]
        [TestCase("Bitesize Scotland: Secondary: Daily: Secondary Programme 5")]
        public void CheckFirstArticleUsingCategoryLinkInSearch(string expectedFirstHeadlineFromSearch)
        {
            BusinessLogicLayer BLL = new BusinessLogicLayer();
            BLL.SearchByCategoryLinkOnNewsPage();
            BLL.CheckTextOfFirstArticleOnSearchPageEqualExpectedText(expectedFirstHeadlineFromSearch);
        }

    }
}
