using NUnit.Framework;
using Shouldly;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    internal class Story1Tests
    {
        // first input contains 2 bad words, so actual result should be 2
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.", 2)]

        // second input contains 0 bad words, so actual result should be 0
        [TestCase("The weather in Manchester in winter is sunny. It must be nice for people visiting.", 0)]
        public void GetNegativeWordsCount_ShouldReturn_CorrectCount_ForThePhrase(string phrase, int expectedNegativeWords)
        {
            // arrange
            var textAnalyserService = new TextAnalyserService();

            var negativeWords = new[] { "swine", "bad", "nasty", "horrible" };

            // act
            var negativeWordsCount = textAnalyserService.GetNegativeWordsCount(phrase, negativeWords);

            // assert
            negativeWordsCount.ShouldBe(expectedNegativeWords);
        }
    }
}