using OpenQA.Selenium;

namespace BBCAndLoremIpsumTest.PageElementsLoremIpsum
{
    public class RadioButton
    {
        public void SetValue(string value)
        {
            Browser.WebDriver.FindElement(By.XPath($"//input[contains(@id,'{value}')]")).Click();
        }

    }
}
