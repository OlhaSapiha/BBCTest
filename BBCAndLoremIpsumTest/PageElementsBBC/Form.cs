using OpenQA.Selenium;
using System.Collections.Generic;

namespace BBCAndLoremIpsumTest.PageElementsBBC
{
    public class Form
    {
        private IWebElement GetFormElement(string field) => Browser.WebDriver.FindElement(By.XPath($"//*[contains(@placeholder,'{field}')]"));

        public void FillForm(Dictionary<string, string> dict)
        {
            foreach (var key in dict.Keys)
            {
                GetFormElement(key).SendKeys(dict[key]);
            }
        }
    }
}
