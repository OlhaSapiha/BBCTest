using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBCAndLoremIpsumTest.PagesBBC
{
    public class Home
    {
        [FindsBy(How = How.XPath, Using = "//div[@id='orb-nav-links']//a[text()='News']")]
        [CacheLookup]
        private IWebElement _newsButton;

        public void ClickNewsButton() => _newsButton.Click();
    }
}
