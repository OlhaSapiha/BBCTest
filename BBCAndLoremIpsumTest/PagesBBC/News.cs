using OpenQA.Selenium;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;

namespace BBCAndLoremIpsumTest.PagesBBC
{
    public class News
    {
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'gs-u-display-none ')]//h3[contains(@class,'gel-paragon-bold')]")]
        [CacheLookup]
        private IWebElement _headlineOfMainArticle;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'nw-c-top-stories__secondary-item')]//h3")]
        [CacheLookup]
        private IList<IWebElement> _secondaryArticleTitles;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'nw-c-top-stories-primary__story')]//div[contains(@class,'gs-u-display-inline-block@m')]//a[contains(@class,'gs-c-section-link')]//span")]
        [CacheLookup]
        private IWebElement _categoryLinkFromHeadlineArticle;

        [FindsBy(How = How.XPath, Using = "//input[@id='orb-search-q']")]
        [CacheLookup]
        private IWebElement _searchInput;

        [FindsBy(How = How.XPath, Using = "//ul[contains(@class,'wide-sections')]//a[contains(@href,'coronavirus')]")]
        [CacheLookup]
        private IWebElement _coronavirusTab;

        [FindsBy(How = How.XPath, Using = "//ul[contains(@class,'nw-c-nav__secondary-sections')]//a[contains(@href,'have_your_say')]")]
        [CacheLookup]
        private IWebElement _yourCoronavirusStoriesTab;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'10725415')]")]
        [CacheLookup]
        private IWebElement _howToShareWithBBCNews;

        public string TextOfHeadlineOfMainArticle => _headlineOfMainArticle.Text;

        public List<string> TextOfSecondaryArticlesTitles
        {
            get
            {
                List<string> list = new List<string>(_secondaryArticleTitles.Count);
                foreach (IWebElement el in _secondaryArticleTitles)
                {
                    list.Add(el.Text);
                }
                return list;
            }
        }

        public string TextOfCategoryLinkFromHeadlineArticle => _categoryLinkFromHeadlineArticle.Text;

        public void SearchByKeywordUsingEnter(string keyword)
        {
            _searchInput.SendKeys(keyword);
            _searchInput.SendKeys(Keys.Enter);
        }

        public void ClickCoronavirusTab() => _coronavirusTab.Click();

        public void ClickYourCoronavirusStoriesTab() => _yourCoronavirusStoriesTab.Click();

        public void ClickHowToShareWithBBCNews() => _howToShareWithBBCNews.Click();
    }
}
