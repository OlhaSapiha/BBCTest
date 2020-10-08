using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using BBCAndLoremIpsumTest.BusinessLogicLayerLoremIpsum;

namespace BBCAndLoremIpsumTest.TestsLoremIpsum
{
    public class GenerateLoremIpsumButtonTests : BaseTestLoremIpsum
    {
        [Test]
        [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit")]
        public void CheckDefaultSettingResultInTextStartsWithLoremIpsum(string start)
        {
            BusinessLogicLayer BLL = new BusinessLogicLayer();
            BLL.GoToGenerateLoremIpsumPage();
            BLL.CheckFirstParagraphStartsWith(start);
        }

        [Test]
        [TestCase(10)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(20)]
        public void CheckLoremIpsumIsGeneratedWithCorrectSizeOfWords(int words)
        {
            BusinessLogicLayer BLL = new BusinessLogicLayer();
            BLL.GenerateWithParameters("words", words);
            BLL.CheckActualAmountOfWordsGeneratedEqualsExpected(words);
        }

        [Test]
        [TestCase(10)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(20)]
        public void CheckLoremIpsumIsGeneratedWithCorrectSizeOfBytes(int bytes)
        {
            BusinessLogicLayer BLL = new BusinessLogicLayer();
            BLL.GenerateWithParameters("bytes", bytes);
            BLL.CheckActualAmountOfBytesGeneratedEqualsExpected(bytes);
        }

        [Test]
        [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit")]
        public void CheckUnchekedBoxResultInTextDoesntStartWithLoremIpsum(string start)
        {
            BusinessLogicLayer BLL = new BusinessLogicLayer();
            BLL.GenerateWithUncheckedBox();
            BLL.CheckFirstParagraphDoesntStartWith(start);
        }

        [Test]
        [TestCase("lorem", 10)]
        public void CheckRandomlyGeneratedTextParagraphsContainTheWord(string word, int times)
        {
            BusinessLogicLayer BLL = new BusinessLogicLayer();
            List<int> countParagraphs = new List<int>();
            for (int i = 0; i < times; i++)
            {
                countParagraphs.Add(BLL.CountRandomlyGeneratedTextParagraphsContainTheWordLorem(word));
                BLL.GoToHomePage();
            }
            double avg = countParagraphs.Average();
            BLL.CheckValueBetweenExpectedValues(avg, 2, 3);
        }

    }
}
