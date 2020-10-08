using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBCAndLoremIpsumTest.PagesBBC
{
    public class Base
    { 
        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'sign_in-exit')]")]
        [CacheLookup]
        private IWebElement _exitSignInFormButton;

        public void ClickExitSignInFormButton() => _exitSignInFormButton.Click();
    }
}
