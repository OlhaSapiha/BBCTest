using NUnit.Framework;
using BBCAndLoremIpsumTest.BusinessLogicLayerLoremIpsum;

namespace BBCAndLoremIpsumTest.TestsLoremIpsum
{
    public class ContainsWordsLoremIpsumTests : BaseTestLoremIpsum
    {
        [Test]
        [TestCase("рыба")]
        public void CheckTheFirstParagraphContainsTheWord(string word)
        {
            BusinessLogicLayer BLL = new BusinessLogicLayer();
            BLL.GoToRussianLoremIpsumPage();
            BLL.CheckFirstParagraphContainsExpectedWord(word);
        }
    }
}
