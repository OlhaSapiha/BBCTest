using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace BBCAndLoremIpsumTest.PagesLoremIpsum
{
    public class Generate
    {
        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'lipsum')]//p[1]")]
        [CacheLookup]
        private IWebElement _paragraphGeneratedFirstParagraph;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'lipsum')]//p")]
        [CacheLookup]
        private IWebElement _wordsAndBytesGeneratedParagraph;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'lipsum')]//p")]
        [CacheLookup]
        private IList<IWebElement> _paragraphGeneratedParagraphs;

        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.lipsum.com/']")]
        [CacheLookup]
        private IWebElement _linkReturnToLoremIpsumHomePage;

        public string TextOfTHeDefaultGeneratedFirstParagraph => _paragraphGeneratedFirstParagraph.Text;

        public List<string> WordsGeneratedParagraphInWordsAsList => _wordsAndBytesGeneratedParagraph.Text.ToString().Split(" ").ToList();

        public void ClickLinkReturnToLoremIpsumHomePage()
        {
            _linkReturnToLoremIpsumHomePage.Click();
        }

        public string TextOfBytesGeneratedParagraph => _wordsAndBytesGeneratedParagraph.Text;

        public IList<IWebElement> GetListOfParagraphsGeneratedByParagraph()
        {
            return _paragraphGeneratedParagraphs;
        }
    }
}
