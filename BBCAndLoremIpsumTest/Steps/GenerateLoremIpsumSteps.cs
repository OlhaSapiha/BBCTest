using TechTalk.SpecFlow;
using BBCAndLoremIpsumTest.PagesLoremIpsum;
using BBCAndLoremIpsumTest.PageElementsLoremIpsum;
using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace BBCAndLoremIpsumTest.Steps
{
    [Binding]
    public class GenerateLoremIpsumSteps
    {
        private ScenarioContext _scenarioContext;
        public GenerateLoremIpsumSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

        }
        private readonly RadioButton rb = new RadioButton();

        [Given(@"the expected start of the paragraph '(.*)'")]
        public void GivenTheExpectedStartOfTheParagraph(string start)
        {
            _scenarioContext["ExpectedStartOfParagraph"] = start;
        }

        [Given(@"the expected (.*) of radio button after generation")]
        public void GivenTheExpectedOfWordsAfterGeneration(int amount)
        {
            _scenarioContext["ExpectedAmountOfRadioButtonGenerated"] = amount;
        }

        [When(@"user goes to Generate Page")]
        public void WhenUserGoesToGeneratePage()
        {
            Page.GetPages<Home>().CLickGenerateLoremIpsumButton();
        }

        [When(@"user generate with radio button '(.*)' and given amount")]
        public void WhenUserGenerateWithRadioButtonAndGivenAmount(string radioButton)
        {
            rb.SetValue(radioButton);
            Page.GetPages<Home>().FillInputAmount(_scenarioContext["ExpectedAmountOfRadioButtonGenerated"].ToString());
            Page.GetPages<Home>().CLickGenerateLoremIpsumButton();
        }

        [Then(@"the paragraph starts with the expected sentence")]
        public void ThenTheParagraphStartsWithTheExpectedSentence()
        {
            Assert.IsTrue(Page.GetPages<Generate>().TextOfTHeDefaultGeneratedFirstParagraph.StartsWith(_scenarioContext["ExpectedStartOfParagraph"].ToString()));

        }

        [Then(@"the expected amount of words is displayed")]
        public void ThenTheExpectedAmountOfWordsIsDisplayed()
        {
            Assert.AreEqual(Int32.Parse(_scenarioContext["ExpectedAmountOfRadioButtonGenerated"].ToString()) <= 5 ? 5 : Int32.Parse(_scenarioContext["ExpectedAmountOfRadioButtonGenerated"].ToString()), Page.GetPages<Generate>().WordsGeneratedParagraphInWordsAsList.Count);
        }

        [Then(@"the expected amount of bytes is displayed")]
        public void ThenTheExpectedAmountOfBytesIsDisplayed()
        {
            Assert.AreEqual(Int32.Parse(_scenarioContext["ExpectedAmountOfRadioButtonGenerated"].ToString()) <= 5 ? 5 : Int32.Parse(_scenarioContext["ExpectedAmountOfRadioButtonGenerated"].ToString()), Page.GetPages<Generate>().TextOfBytesGeneratedParagraph.Length);
        }

        [When(@"user generate with unchecked box")]
        public void WhenUserGenerateWithUncheckedBox()
        {
            Page.GetPages<Home>().ClickCheckBoxStartWith();
            Page.GetPages<Home>().CLickGenerateLoremIpsumButton();
        }

        [Then(@"the paragraph doesn't start with the expected sentence")]
        public void ThenTheParagraphDoesnTStartWithTheExpectedSentence()
        {
            Assert.IsFalse(Page.GetPages<Generate>().TextOfTHeDefaultGeneratedFirstParagraph.StartsWith(_scenarioContext["ExpectedStartOfParagraph"].ToString()));
        }

        [Given(@"the expected word paragraph contains '(.*)'")]
        public void GivenTheExpectedWordParagraphContains(string word)
        {
            _scenarioContext["ExpectedWordParagraphContains"] = word;
        }

        [Given(@"how many times checked '(.*)'")]
        public void GivenHowManyTimesChecked(int times)
        {
            _scenarioContext["TimesToGenerate"] = times;
        }

        [When(@"user counts how many paragraphs contains the given word")]
        public void WhenUserCountsHowManyParagraphsContainsTheGivenWord()
        {
            IList<IWebElement> paragraphs = Page.GetPages<Generate>().GetListOfParagraphsGeneratedByParagraph();
            int count = 0;
            foreach (IWebElement el in paragraphs)
            {
                if (el.Text.ToString().Contains(_scenarioContext["ExpectedWordParagraphContains"].ToString())) count++;
            }
            _scenarioContext["AmountOfParagraphsContainTheWord"] = count;
        }

        [When(@"user returns to Home Page")]
        public void WhenUserReturnsToHomePage()
        {
            Page.GetPages<Generate>().ClickLinkReturnToLoremIpsumHomePage();
        }

        [Then(@"the average value of paragraphs generated given times containing the given word should be between '(.*)' and '(.*)'")]
        public void ThenTheAverageValueOfParagraphsGeneratedGivenTimesContainingTheGivenWordShouldBeBetweenAnd(int valMin, int valMax)
        {
            List<int> countParagraphs = new List<int>();
            countParagraphs.Add(Int32.Parse(_scenarioContext["AmountOfParagraphsContainTheWord"].ToString()));
            for (int i = 0; i < Int32.Parse(_scenarioContext["TimesToGenerate"].ToString()) - 1; i++)
            {
                WhenUserGoesToGeneratePage();
                WhenUserCountsHowManyParagraphsContainsTheGivenWord();
                countParagraphs.Add(Int32.Parse(_scenarioContext["AmountOfParagraphsContainTheWord"].ToString()));
                WhenUserReturnsToHomePage();
            }
            double avg = countParagraphs.Average();
            Assert.IsTrue(avg <= valMax && avg >= valMin);
        }


    }
}
