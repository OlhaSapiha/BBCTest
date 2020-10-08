using BBCAndLoremIpsumTest.PageElementsLoremIpsum;
using BBCAndLoremIpsumTest.PagesLoremIpsum;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace BBCAndLoremIpsumTest.BusinessLogicLayerLoremIpsum
{
    public class BusinessLogicLayer
    {
        private readonly RadioButton rb = new RadioButton();

        public void GoToRussianLoremIpsumPage()
        {
            Page.GetPages<Home>().ClickLinkRussianLanguage();
        }

        public void CheckFirstParagraphContainsExpectedWord(string word)
        {
            Assert.IsTrue(Page.GetPages<Home>().TextOfTheFirstParagraph.Contains(word));
        }

        public void GoToGenerateLoremIpsumPage()
        {
            Page.GetPages<Home>().CLickGenerateLoremIpsumButton();
        }

        public void CheckFirstParagraphStartsWith(string start)
        {
            Assert.IsTrue(Page.GetPages<Generate>().TextOfTHeDefaultGeneratedFirstParagraph.StartsWith(start));
        }

        public void CheckFirstParagraphDoesntStartWith(string start)
        {
            Assert.IsFalse(Page.GetPages<Generate>().TextOfTHeDefaultGeneratedFirstParagraph.StartsWith(start));
        }

        public void GenerateWithParameters(string radioButton, int amount)
        {
            rb.SetValue(radioButton);
            Page.GetPages<Home>().FillInputAmount(amount.ToString());
            Page.GetPages<Home>().CLickGenerateLoremIpsumButton();
        }

        public void CheckActualAmountOfWordsGeneratedEqualsExpected(int words)
        {
            Assert.AreEqual(words <= 5 ? 5 : words, Page.GetPages<Generate>().WordsGeneratedParagraphInWordsAsList.Count);
        }

        public void CheckActualAmountOfBytesGeneratedEqualsExpected(int bytes)
        {
            Assert.AreEqual(bytes <= 5 ? 5 : bytes, Page.GetPages<Generate>().TextOfBytesGeneratedParagraph.Length);
        }

        public void GenerateWithUncheckedBox()
        {
            Page.GetPages<Home>().ClickCheckBoxStartWith();
            Page.GetPages<Home>().CLickGenerateLoremIpsumButton();
        }

        public int CountRandomlyGeneratedTextParagraphsContainTheWordLorem(string word)
        {
            Page.GetPages<Home>().CLickGenerateLoremIpsumButton();
            IList<IWebElement> paragraphs = Page.GetPages<Generate>().GetListOfParagraphsGeneratedByParagraph();
            int count = 0;
            foreach (IWebElement el in paragraphs)
            {
                if (el.Text.ToString().Contains(word)) count++;
            }
            return count;
        }

        public void GoToHomePage()
        {
            Page.GetPages<Generate>().ClickLinkReturnToLoremIpsumHomePage();
        }

        public void CheckValueBetweenExpectedValues(double val, int valMin, int valMax)
        {
            Assert.IsTrue(val <= valMax && val >= valMin);
        }
    }
}
