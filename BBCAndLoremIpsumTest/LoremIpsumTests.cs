using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BBCTest
{
    public class LoremIpsumTests
    {
        private const string _loremIpsumUrl = "https://lipsum.com/";

        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_loremIpsumUrl);
        }

        [Test]
        public void CheckTheFirstParagraphContainsTheWord()
        {
            driver.FindElement(By.XPath("//a[contains(@class,'ru')]")).Click();
            string paragraph = driver.FindElement(By.XPath("//div[contains(@id,'Panes')]//div[1]//p"), 20).Text.ToString();
            Assert.IsTrue(paragraph.Contains("рыба"));
        }

        [Test]
        public void CheckDefaultSettingResultInTextStartsWithLoremIpsum()
        {
            driver.FindElement(By.XPath("//input[contains(@id,'generate')]")).Click();
            string paragraph = driver.FindElement(By.XPath("//div[contains(@id,'lipsum')]//p[1]"), 20).Text.ToString();
            Assert.IsTrue(paragraph.StartsWith("Lorem ipsum dolor sit amet, consectetur adipiscing elit"));
        }

        public void CheckLoremIpsumIsGeneratedWithCorrectSizeOfWords(int words)
        {
            driver.FindElement(By.XPath("//input[contains(@id,'words')]")).Click();
            IWebElement input = driver.FindElement(By.XPath("//input[contains(@id,'amount')]"));
            input.Clear();
            input.SendKeys(words.ToString());
            driver.FindElement(By.XPath("//input[contains(@id,'generate')]")).Click();
            List<string> paragraph = driver.FindElement(By.XPath("//div[contains(@id,'lipsum')]//p"), 20).Text.ToString().Split(" ").ToList();
            Assert.AreEqual(words <= 5 ? 5 : words, paragraph.Count);
        }

        [Test]
        public void CheckLoremIpsumIsGeneratedWithDifferentSizesOfWords()
        {
            CheckLoremIpsumIsGeneratedWithCorrectSizeOfWords(10);
            driver.FindElement(By.XPath("//a[@href='https://www.lipsum.com/']")).Click();
            CheckLoremIpsumIsGeneratedWithCorrectSizeOfWords(-1);
            driver.FindElement(By.XPath("//a[@href='https://www.lipsum.com/']")).Click();
            CheckLoremIpsumIsGeneratedWithCorrectSizeOfWords(0);
            driver.FindElement(By.XPath("//a[@href='https://www.lipsum.com/']")).Click();
            CheckLoremIpsumIsGeneratedWithCorrectSizeOfWords(5);
            driver.FindElement(By.XPath("//a[@href='https://www.lipsum.com/']")).Click();
            CheckLoremIpsumIsGeneratedWithCorrectSizeOfWords(20);
        }

        public void CheckLoremIpsumIsGeneratedWithCorrectSizeOfBytes(int bytes)
        {
            driver.FindElement(By.XPath("//input[contains(@id,'bytes')]")).Click();
            IWebElement input = driver.FindElement(By.XPath("//input[contains(@id,'amount')]"));
            input.Clear();
            input.SendKeys(bytes.ToString());
            driver.FindElement(By.XPath("//input[contains(@id,'generate')]")).Click();
            string paragraph = driver.FindElement(By.XPath("//div[contains(@id,'lipsum')]//p"), 20).Text.ToString();
            Assert.AreEqual(bytes <= 5 ? 5 : bytes, paragraph.Length);
        }

        [Test]
        public void CheckLoremIpsumIsGeneratedWithDifferentSizesOfBytes()
        {
            CheckLoremIpsumIsGeneratedWithCorrectSizeOfBytes(10);
            driver.FindElement(By.XPath("//a[@href='https://www.lipsum.com/']")).Click();
            CheckLoremIpsumIsGeneratedWithCorrectSizeOfBytes(-1);
            driver.FindElement(By.XPath("//a[@href='https://www.lipsum.com/']")).Click();
            CheckLoremIpsumIsGeneratedWithCorrectSizeOfBytes(0);
            driver.FindElement(By.XPath("//a[@href='https://www.lipsum.com/']")).Click();
            CheckLoremIpsumIsGeneratedWithCorrectSizeOfBytes(20);
        }

        [Test]
        public void CheckUnchekedBoxResultInTextDoesntStartWithLoremIpsum()
        {
            driver.FindElement(By.XPath("//input[@id='start']")).Click();
            driver.FindElement(By.XPath("//input[contains(@id,'generate')]")).Click();
            string paragraph = driver.FindElement(By.XPath("//div[contains(@id,'lipsum')]//p[1]"), 20).Text.ToString();
            Assert.IsFalse(paragraph.StartsWith("Lorem ipsum dolor sit amet, consectetur adipiscing elit"));
        }

        public int CountRandomlyGeneratedTextParagraphsContainTheWordLorem()
        {
            driver.FindElement(By.XPath("//input[contains(@id,'generate')]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IList<IWebElement> paragraphs = driver.FindElements(By.XPath("//div[contains(@id,'lipsum')]//p"));
            int count = 0;
            foreach(IWebElement el in paragraphs)
            {
                if (el.Text.ToString().Contains("lorem")) count++;
            }
            driver.FindElement(By.XPath("//a[@href='https://www.lipsum.com/']")).Click();
            return count;
        }

        [Test]
        public void CheckRandomlyGeneratedTextParagraphsContainTheWordLorem()
        {
            List<int> countParagraphs = new List<int>();
            for(int i = 0; i < 10; i++)
            {
                countParagraphs.Add(CountRandomlyGeneratedTextParagraphsContainTheWordLorem());
            }
            double avg = countParagraphs.Average();
            Assert.IsTrue(avg <= 3 && avg >= 2);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
