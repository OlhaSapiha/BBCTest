using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BBCAndLoremIpsumTest.PagesBBC
{
    public class HowToShare
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='checkbox'][2]//input")]
        [CacheLookup]
        private IWebElement _over16CheckBox;

        [FindsBy(How = How.XPath, Using = "//div[@class='checkbox'][3]//input")]
        [CacheLookup]
        private IWebElement _acceptTermsOfServiceCheckBox;

        [FindsBy(How = How.XPath, Using = "//button[text()='Submit']")]
        [CacheLookup]
        private IWebElement _submitButton;

        [FindsBy(How = How.XPath, Using = "//textarea[contains(@class,'error')]")]
        [CacheLookup]
        private IWebElement _tellUsYourStoryInputRed;

        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'error')]")]
        [CacheLookup]
        private IWebElement _inputRed;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'error')]")]
        [CacheLookup]
        private IWebElement _errorMessageUnderInput;

        public bool DisplayedTellUsYourStoryInputRed()
        {
            return _tellUsYourStoryInputRed.ControlDisplayed();
        }

        public bool DisplayedInputred()
        {
            return _inputRed.ControlDisplayed();
        }

        public bool DisplayedErrorMessageUnderInput()
        {
            return _errorMessageUnderInput.ControlDisplayed();
        }

        public void ClickOver16CheckBox() => _over16CheckBox.Click();

        public void ClickAcceptTermsOfServiceCheckBox() => _acceptTermsOfServiceCheckBox.Click();

        public void ClickSubmitButton() => _submitButton.Click();

        public string TextOfErrorMessage => _errorMessageUnderInput.Text;

    }
}
