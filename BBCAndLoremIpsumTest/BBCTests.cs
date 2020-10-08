using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BBCTest
{
    public class BBCTests
    {
        private const string _bbcUrl = "https://www.bbc.com";

        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_bbcUrl);
        }

        [Test]
        public void CheckTheNameOfTheHeadlineArticle()
        {
            driver.FindElement(By.XPath("//div[@id='orb-nav-links']//a[text()='News']")).Click();
            driver.FindElement(By.XPath("//button[@class='sign_in-exit']"), 10).Click();
            string actualHeadlineArticle = driver.FindElement(By.XPath("//div[contains(@class,'gs-u-display-inline-block@m')]//h3[@class='gs-c-promo-heading__title gel-paragon-bold nw-o-link-split__text']")).Text;
            Assert.AreEqual("Biden calls for police to be charged in shootings", actualHeadlineArticle);
        }

        [Test]
        public void CheckSecondaryArticleTitles()
        {
            driver.FindElement(By.XPath("//div[@id='orb-nav-links']//a[text()='News']")).Click();
            driver.FindElement(By.XPath("//button[@class='sign_in-exit']"), 10).Click();
            IList<IWebElement> actualArticleTitlesElements = driver.FindElements(By.XPath("//div[contains(@class,'nw-c-top-stories__secondary-item')]//h3"));
            List<string> expectedSecondaryArticles = new List<string>(5)
            {
                "NY black man killed in police 'spit hood' restraint",
                "Dwayne 'The Rock' Johnson and family had Covid-19",
                "Russian opposition leader 'poisoned with Novichok'",
                "'I'm gonna go finish feeding my daughter'",
                "Australia 'anti-lockdown' arrest stirs controversy"
            };
            Assert.AreEqual(expectedSecondaryArticles.Count, actualArticleTitlesElements.Count);
            for (int i = 0; i < actualArticleTitlesElements.Count; i++)
            {
                Assert.AreEqual(expectedSecondaryArticles[i], actualArticleTitlesElements[i].Text);
            }
        }

        [Test]
        public void CheckFirstArticleUsingCategoryLinkInSearch()
        {
            IWebElement element = driver.FindElement(By.XPath("//div[@id='orb-nav-links']//a[text()='News']"));
            element.Click();
            driver.FindElement(By.XPath("//button[@class='sign_in-exit']"), 10).Click();
            string categoryLink = driver.FindElement(By.XPath("//div[contains(@class,'nw-c-top-stories-primary__story')]//div[contains(@class,'gs-u-display-inline-block@m')]//a[contains(@class,'gs-c-section-link')]//span")).Text;
            IWebElement searchInput = driver.FindElement(By.XPath("//input[@id='orb-search-q']"));
            searchInput.SendKeys(categoryLink);
            searchInput.SendKeys(Keys.Enter);
            string actualHeadline = driver.FindElement(By.XPath("//ul[@class='css-1lb37cz-Stack e1y4nx260']//li[1]//a//span")).Text;
            Assert.AreEqual(actualHeadline, "Bitesize Scotland: Secondary: Daily: Secondary Programme 5");
        }

        [Test]
        public void CheckErrorMessageWhenUserSubmitQuestionToBBCWithEmptyTellUsYourStory()
        {
            IWebElement element = driver.FindElement(By.XPath("//div[@id='orb-nav-links']//a[text()='News']"));
            element.Click();
            driver.FindElement(By.XPath("//button[@class='sign_in-exit']"), 10).Click();
            driver.FindElement(By.XPath("//ul[@class='gs-o-list-ui--top-no-border nw-c-nav__wide-sections']//a[contains(@href,'coronavirus')]")).Click();
            driver.FindElement(By.XPath("//ul[@class='gs-o-list-ui--top-no-border nw-c-nav__secondary-sections']//a[contains(@href,'have_your_say')]"), 10).Click();
            driver.FindElement(By.XPath("//a[contains(@href,'10725415')]"), 10).Click();
            IWebElement nameInput = driver.FindElement(By.XPath("//input[@placeholder='Name']"), 10);
            nameInput.SendKeys("Olha");
            IWebElement emailInput = driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
            emailInput.SendKeys("osapiha5553@gmail.com");
            IWebElement contactInput = driver.FindElement(By.XPath("//input[@placeholder='Contact number ']"));
            contactInput.SendKeys("+380931256769");
            IWebElement locationInput = driver.FindElement(By.XPath("//input[@placeholder='Location ']"));
            locationInput.SendKeys("Kyiv");
            driver.FindElement(By.XPath("//div[@class='checkbox'][2]//input")).Click();
            driver.FindElement(By.XPath("//div[@class='checkbox'][3]//input")).Click();
            driver.FindElement(By.XPath("//button[text()='Submit']")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//textarea[@class='text-input--long--error']"), 10).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='input-error-message']"), 10).Displayed);
            Assert.AreEqual(driver.FindElement(By.XPath("//div[@class='input-error-message']")).Text, "can't be blank");
        }

        [Test]
        public void CheckErrorMessageWhenUserSubmitQuestionToBBCWithInvalidEmail()
        {
            IWebElement element = driver.FindElement(By.XPath("//div[@id='orb-nav-links']//a[text()='News']"));
            element.Click();
            driver.FindElement(By.XPath("//button[@class='sign_in-exit']"), 10).Click();
            driver.FindElement(By.XPath("//ul[@class='gs-o-list-ui--top-no-border nw-c-nav__wide-sections']//a[contains(@href,'coronavirus')]")).Click();
            driver.FindElement(By.XPath("//ul[@class='gs-o-list-ui--top-no-border nw-c-nav__secondary-sections']//a[contains(@href,'have_your_say')]"), 10).Click();
            driver.FindElement(By.XPath("//a[contains(@href,'10725415')]"), 10).Click();
            IWebElement tellUsInput = driver.FindElement(By.XPath("//textarea[@placeholder='Tell us your story. ']"), 10);
            tellUsInput.SendKeys("Hello!");
            IWebElement nameInput = driver.FindElement(By.XPath("//input[@placeholder='Name']"), 10);
            nameInput.SendKeys("Olha");
            IWebElement emailInput = driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
            emailInput.SendKeys("osapiha5553");
            IWebElement contactInput = driver.FindElement(By.XPath("//input[@placeholder='Contact number ']"));
            contactInput.SendKeys("+380931256769");
            IWebElement locationInput = driver.FindElement(By.XPath("//input[@placeholder='Location ']"));
            locationInput.SendKeys("Kyiv");
            driver.FindElement(By.XPath("//div[@class='checkbox'][2]//input")).Click();
            driver.FindElement(By.XPath("//div[@class='checkbox'][3]//input")).Click();
            driver.FindElement(By.XPath("//button[text()='Submit']")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//input[@class='text-input--error__input']"), 10).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='input-error-message']"), 10).Displayed);
            Assert.AreEqual(driver.FindElement(By.XPath("//div[@class='input-error-message']")).Text, "Email address is invalid");
        }

        [Test]
        public void CheckErrorMessageWhenUserSubmitQuestionToBBCWithUncheckedAcceptTermsService()
        {
            IWebElement element = driver.FindElement(By.XPath("//div[@id='orb-nav-links']//a[text()='News']"));
            element.Click();
            driver.FindElement(By.XPath("//button[@class='sign_in-exit']"), 10).Click();
            driver.FindElement(By.XPath("//ul[@class='gs-o-list-ui--top-no-border nw-c-nav__wide-sections']//a[contains(@href,'coronavirus')]")).Click();
            driver.FindElement(By.XPath("//ul[@class='gs-o-list-ui--top-no-border nw-c-nav__secondary-sections']//a[contains(@href,'have_your_say')]"), 10).Click();
            driver.FindElement(By.XPath("//a[contains(@href,'10725415')]"), 10).Click();
            IWebElement tellUsInput = driver.FindElement(By.XPath("//textarea[@placeholder='Tell us your story. ']"), 10);
            tellUsInput.SendKeys("Hello!");
            IWebElement nameInput = driver.FindElement(By.XPath("//input[@placeholder='Name']"), 10);
            nameInput.SendKeys("Olha");
            IWebElement emailInput = driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
            emailInput.SendKeys("osapiha5553@gmail.com");
            IWebElement contactInput = driver.FindElement(By.XPath("//input[@placeholder='Contact number ']"));
            contactInput.SendKeys("+380931256769");
            IWebElement locationInput = driver.FindElement(By.XPath("//input[@placeholder='Location ']"));
            locationInput.SendKeys("Kyiv");
            driver.FindElement(By.XPath("//div[@class='checkbox'][2]//input")).Click();
            driver.FindElement(By.XPath("//button[text()='Submit']")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='input-error-message']"), 10).Displayed);
            Assert.AreEqual(driver.FindElement(By.XPath("//div[@class='input-error-message']")).Text, "must be accepted");
        }

        [Test]
        public void CheckErrorMessageWhenUserSubmitQuestionToBBCWithEmptyName()
        {
            IWebElement element = driver.FindElement(By.XPath("//div[@id='orb-nav-links']//a[text()='News']"));
            element.Click();
            driver.FindElement(By.XPath("//button[@class='sign_in-exit']"), 10).Click();
            driver.FindElement(By.XPath("//ul[@class='gs-o-list-ui--top-no-border nw-c-nav__wide-sections']//a[contains(@href,'coronavirus')]")).Click();
            driver.FindElement(By.XPath("//ul[@class='gs-o-list-ui--top-no-border nw-c-nav__secondary-sections']//a[contains(@href,'have_your_say')]"), 10).Click();
            driver.FindElement(By.XPath("//a[contains(@href,'10725415')]"), 10).Click();
            IWebElement tellUsInput = driver.FindElement(By.XPath("//textarea[@placeholder='Tell us your story. ']"), 10);
            tellUsInput.SendKeys("Hello!");
            IWebElement emailInput = driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
            emailInput.SendKeys("osapiha5553@gmail.com");
            IWebElement contactInput = driver.FindElement(By.XPath("//input[@placeholder='Contact number ']"));
            contactInput.SendKeys("+380931256769");
            IWebElement locationInput = driver.FindElement(By.XPath("//input[@placeholder='Location ']"));
            locationInput.SendKeys("Kyiv");
            driver.FindElement(By.XPath("//div[@class='checkbox'][2]//input")).Click();
            driver.FindElement(By.XPath("//div[@class='checkbox'][3]//input")).Click();
            driver.FindElement(By.XPath("//button[text()='Submit']")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//input[@class='text-input--error__input']"), 10).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='input-error-message']"), 10).Displayed);
            Assert.AreEqual(driver.FindElement(By.XPath("//div[@class='input-error-message']")).Text, "Name can't be blank");
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }

    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}
