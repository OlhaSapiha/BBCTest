using System.Collections.Generic;
using BBCAndLoremIpsumTest.PageElementsBBC;
using BBCAndLoremIpsumTest.PagesBBC;
using NUnit.Framework;

namespace BBCAndLoremIpsumTest.BusinessLogicLayerBBC
{
    public sealed class BusinessLogicLayer
    {
        private readonly Form Form = new Form();
        public void GoToNewsPageAndCloseSignInWindow()
        {
            Page.GetPages<Home>().ClickNewsButton();
            Page.GetPages<Base>().ClickExitSignInFormButton();
        }

        public void CheckTextOfHeadlineArticleEqualExpectedText(string expected)
        {
            Assert.AreEqual(Page.GetPages<News>().TextOfHeadlineOfMainArticle, expected);
        }

        public void CheckNumberOfSecondaryArticlesEqualExpectedNumber(List<string> list)
        {
            Assert.AreEqual(list.Count, Page.GetPages<News>().TextOfSecondaryArticlesTitles.Count);
        }
        public void CheckTextOfSecondaryArticlesEqualExpectedText(List<string> list)
        {
            for (int i = 0; i < Page.GetPages<News>().TextOfSecondaryArticlesTitles.Count; i++)
            {
                Assert.AreEqual(Page.GetPages<News>().TextOfSecondaryArticlesTitles[i], list[i]);
            }
        }

        public void SearchByCategoryLinkOnNewsPage()
        {
            GoToNewsPageAndCloseSignInWindow();
            Page.GetPages<News>().SearchByKeywordUsingEnter(Page.GetPages<News>().TextOfCategoryLinkFromHeadlineArticle);
        }

        public void CheckTextOfFirstArticleOnSearchPageEqualExpectedText(string expected)
        {
            Assert.AreEqual(Page.GetPages<Search>().TextOfFirstHeadline, expected);
        }

        public void GoToHowToSharePage()
        {
            Page.GetPages<Home>().ClickNewsButton();
            Page.GetPages<Base>().ClickExitSignInFormButton();
            Page.GetPages<News>().ClickCoronavirusTab();
            Page.GetPages<News>().ClickYourCoronavirusStoriesTab();
            Page.GetPages<News>().ClickHowToShareWithBBCNews();
        }

        public void SubmitQuestionToBBC(string story, string name, string email, string contact, string location, bool over16Box, bool termsBox)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
            { "Tell", story },
            { "Name", name },
            { "Email", email },
            { "Contact", contact },
            { "Location", location}
            };
            Form.FillForm(dict);
            if (over16Box) Page.GetPages<HowToShare>().ClickOver16CheckBox();
            if (termsBox) Page.GetPages<HowToShare>().ClickAcceptTermsOfServiceCheckBox();
            Page.GetPages<HowToShare>().ClickSubmitButton();
        }

        public void CheckFormWithEmptyTellUsYourStory(string expectedErrorMessage)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Page.GetPages<HowToShare>().DisplayedTellUsYourStoryInputRed());
                Assert.IsTrue(Page.GetPages<HowToShare>().DisplayedErrorMessageUnderInput());
                Assert.AreEqual(Page.GetPages<HowToShare>().TextOfErrorMessage, expectedErrorMessage);
            });
        }

        public void CheckFormWithInvalidEmail(string expectedErrorMessage)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Page.GetPages<HowToShare>().DisplayedInputred());
                Assert.IsTrue(Page.GetPages<HowToShare>().DisplayedErrorMessageUnderInput());
                Assert.AreEqual(Page.GetPages<HowToShare>().TextOfErrorMessage, expectedErrorMessage);
            });
        }

        public void CheckFormWithUncheckedBox(string expectedErrorMessage)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(Page.GetPages<HowToShare>().DisplayedErrorMessageUnderInput());
                Assert.AreEqual(Page.GetPages<HowToShare>().TextOfErrorMessage, expectedErrorMessage);
            });
        }

        public void CheckFormWithEmptyName(string expectedErrorMessage)
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
