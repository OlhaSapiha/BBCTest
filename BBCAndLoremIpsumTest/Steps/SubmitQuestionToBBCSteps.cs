using BBCAndLoremIpsumTest.PageElementsBBC;
using BBCAndLoremIpsumTest.PagesBBC;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BBCAndLoremIpsumTest.Steps
{
    [Binding]
    public class SubmitQuestionToBBCSteps
    {
        private ScenarioContext _scenarioContext;
        public SubmitQuestionToBBCSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

        }

        private readonly Form Form = new Form();

        [Given(@"the credentials and over16Box '(.*)' and termsBox '(.*)' to submit the form")]
        public void GivenTheCredentialsOverBoxAndTermsBoxAndToSubmitTheForm(string over16, string terms, Table table)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dict.Add(row[0], row[1]);
            }
            _scenarioContext.Add("Credentials", dict);
            _scenarioContext["Over16Box"] = over16;
            _scenarioContext["TermsBox"] = terms;
        }

        [When(@"user goes to the Coronavirus tab")]
        public void GivenUserGoesToTheCoronavirusTab()
        {
            Page.GetPages<News>().ClickCoronavirusTab();
        }

        [When(@"user goes to the Your coronavirus stories tab")]
        public void GivenUserGoesToTheYourCoronavirusStoriesTab()
        {
            Page.GetPages<News>().ClickYourCoronavirusStoriesTab();
        }

        [When(@"user goes to the How to share with BBC News page")]
        public void GivenUserGoesToTheHowToShareWithBBCNewsPage()
        {
            Page.GetPages<News>().ClickHowToShareWithBBCNews();
        }

        [When(@"user submits form with given credentials")]
        public void WhenUserSubmitsFormWithCredentialsAndOverBoxAndTermsBox()
        {
            Dictionary<string, string> dict = _scenarioContext["Credentials"] as Dictionary<string, string>;
            Form.FillForm(dict);
            if (Convert.ToBoolean(_scenarioContext["Over16Box"])) Page.GetPages<HowToShare>().ClickOver16CheckBox();
            if (Convert.ToBoolean(_scenarioContext["TermsBox"])) Page.GetPages<HowToShare>().ClickAcceptTermsOfServiceCheckBox();
            Page.GetPages<HowToShare>().ClickSubmitButton();
        }

        [Then(@"the error message '(.*)' is shown under the field Tell")]
        public void ThenTheErrorMessageIsShownUnderTheFieldTell(string expectedErrorMessage)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Page.GetPages<HowToShare>().DisplayedTellUsYourStoryInputRed());
                Assert.IsTrue(Page.GetPages<HowToShare>().DisplayedErrorMessageUnderInput());
                Assert.AreEqual(Page.GetPages<HowToShare>().TextOfErrorMessage, expectedErrorMessage);
            });
        }

        [Then(@"the error message '(.*)' is shown under the email field")]
        public void ThenTheErrorMessageIsShownUnderTheEmailField(string expectedErrorMessage)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Page.GetPages<HowToShare>().DisplayedInputred());
                Assert.IsTrue(Page.GetPages<HowToShare>().DisplayedErrorMessageUnderInput());
                Assert.AreEqual(Page.GetPages<HowToShare>().TextOfErrorMessage, expectedErrorMessage);
            });
        }

        [Then(@"the error message '(.*)' is shown under the unchecked box")]
        public void ThenTheErrorMessageIsShownUnderTheUncheckedBox(string expectedErrorMessage)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Page.GetPages<HowToShare>().DisplayedErrorMessageUnderInput());
                Assert.AreEqual(Page.GetPages<HowToShare>().TextOfErrorMessage, expectedErrorMessage);
            });
        }

        [Then(@"the error message '(.*)' is shown under the name field")]
        public void ThenTheErrorMessageIsShownUnderTheNameField(string expectedErrorMessage)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Page.GetPages<HowToShare>().DisplayedInputred());
                Assert.IsTrue(Page.GetPages<HowToShare>().DisplayedErrorMessageUnderInput());
                Assert.AreEqual(Page.GetPages<HowToShare>().TextOfErrorMessage, expectedErrorMessage);
            });
        }

    }
}
