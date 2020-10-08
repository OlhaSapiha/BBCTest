using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBCAndLoremIpsumTest.PagesLoremIpsum
{
    public class Home
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'ru')]")]
        [CacheLookup]
        private IWebElement _linkRusssianLanguage;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'Panes')]//div[1]//p")]
        [CacheLookup]
        private IWebElement _firstParagraph;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'generate')]")]
        [CacheLookup]
        private IWebElement _generateLoremIpsumButton;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'words')]")]
        [CacheLookup]
        private IWebElement _inputWords;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'amount')]")]
        [CacheLookup]
        private IWebElement _inputAmount;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'bytes')]")]
        [CacheLookup]
        private IWebElement _inputBytes;

        [FindsBy(How = How.XPath, Using = "//input[@id='start']")]
        [CacheLookup]
        private IWebElement _checkBoxStartWith;

        public void ClickLinkRussianLanguage()
        {
            _linkRusssianLanguage.Click();
        }

        public string TextOfTheFirstParagraph => _firstParagraph.Text;

        public void CLickGenerateLoremIpsumButton()
        {
            _generateLoremIpsumButton.Click();
        }

        public void ClickInputWords()
        {
            _inputWords.Click();
        }

        public void FillInputAmount(string amount)
        {
            _inputAmount.Clear();
            _inputAmount.SendKeys(amount);
        }

        public void ClickInputBytes()
        {
            _inputBytes.Click();
        }

        public void ClickCheckBoxStartWith()
        {
            _checkBoxStartWith.Click();
        }
    }
}
