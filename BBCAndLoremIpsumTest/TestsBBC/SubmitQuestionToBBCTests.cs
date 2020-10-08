using NUnit.Framework;
using BBCAndLoremIpsumTest.BusinessLogicLayerBBC;

namespace BBCAndLoremIpsumTest.TestsBBC
{
    public class SubmitQuestionToBBCTests : BaseTestBBC
    {
        [Test]
        [TestCase("", "Olha", "osapiha5553@gmail.com", "+380931256769", "Kyiv", true, true)]
        public void CheckErrorMessageWhenUserSubmitQuestionToBBCWithEmptyTellUsYourStory(string story, string name, string email, string contact, string location, bool over16Box, bool termsBox)
        {
            BusinessLogicLayer BLL = new BusinessLogicLayer();
            BLL.GoToHowToSharePage();
            BLL.SubmitQuestionToBBC(story, name, email, contact, location, over16Box, termsBox);
            BLL.CheckFormWithEmptyTellUsYourStory("can't be blank");
        }

        [Test]
        [TestCase("Hello!", "Olha", "osapiha5553", "+380931256769", "Kyiv", true, true)]
        public void CheckErrorMessageWhenUserSubmitQuestionToBBCWithInvalidEmail(string story, string name, string email, string contact, string location, bool over16Box, bool termsBox)
        {
            BusinessLogicLayer BLL = new BusinessLogicLayer();
            BLL.GoToHowToSharePage();
            BLL.SubmitQuestionToBBC(story, name, email, contact, location, over16Box, termsBox);
            BLL.CheckFormWithInvalidEmail("Email address is invalid");
        }

        [Test]
        [TestCase("Hello!", "Olha", "osapiha5553@gmail.com", "+380931256769", "Kyiv", true, false)]
        public void CheckErrorMessageWhenUserSubmitQuestionToBBCWithUncheckedAcceptTermsService(string story, string name, string email, string contact, string location, bool over16Box, bool termsBox)
        {
            BusinessLogicLayer BLL = new BusinessLogicLayer();
            BLL.GoToHowToSharePage();
            BLL.SubmitQuestionToBBC(story, name, email, contact, location, over16Box, termsBox);
            BLL.CheckFormWithUncheckedBox("must be accepted");
        }

        [Test]
        [TestCase("Hello!", "", "osapiha5553@gmail.com", "+380931256769", "Kyiv", true, true)]
        public void CheckErrorMessageWhenUserSubmitQuestionToBBCWithEmptyName(string story, string name, string email, string contact, string location, bool over16Box, bool termsBox)
        {
            BusinessLogicLayer BLL = new BusinessLogicLayer();
            BLL.GoToHowToSharePage();
            BLL.SubmitQuestionToBBC(story, name, email, contact, location, over16Box, termsBox);
            BLL.CheckFormWithEmptyName("Name can't be blank");
        }

    }
}
