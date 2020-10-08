using System;
using System.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BBCAndLoremIpsumTest
{
    public static class Browser
    {
        private static IWebDriver webDriver;

        public static IWebDriver WebDriver
        {
            get
            {
                if (webDriver == null)
                {
                    webDriver = new ChromeDriver();
                }
                return webDriver;
            }
        }

        public static void Init(string url)
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            WebDriver.Manage().Window.Maximize();
            Goto(url);
        }

        public static void Goto(string url) => WebDriver.Navigate().GoToUrl(url); 

        public static string SaveScreenshotAndReturnPath()
        {
            var screenshot = ((ITakesScreenshot)WebDriver).GetScreenshot();
            screenshot.SaveAsFile(@"D:\INSTALL\screenshots\Screenshot_" + TestContext.CurrentContext.Test.MethodName.ToString() + ".png", ScreenshotImageFormat.Png);
            return @"D:\INSTALL\screenshots\Screenshot_" + TestContext.CurrentContext.Test.MethodName.ToString() + ".png";
        }

        public static void Close()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                TestContext.AddTestAttachment(SaveScreenshotAndReturnPath());

            }
            webDriver.Quit();
        }

        //extension
        public static bool ControlDisplayed(this IWebElement element, bool displayed = true, uint timeoutInSeconds = 60)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(Exception));
            return wait.Until(drv =>
            {
                if (!displayed && !element.Displayed || displayed && element.Displayed)
                {
                    return true;
                }
                return false;
            });
        }
    }
}
