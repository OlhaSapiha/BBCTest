using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBCAndLoremIpsumTest.PagesBBC
{
    public class Search
    {
        [FindsBy(How = How.XPath, Using = "//ul[contains(@class,'Stack')]//li[1]//a//span")]
        [CacheLookup]
        private IWebElement _firstHeadline;

        public string TextOfFirstHeadline => _firstHeadline.Text;
    }
}
