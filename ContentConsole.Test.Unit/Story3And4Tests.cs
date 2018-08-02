using NUnit.Framework;
using Shouldly;

namespace ContentConsole.Test.Unit
{
    public class Story3And4Tests
    {
        // first input contains 2 bad words, so actual result should be masked
        [TestCase
            ("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.",
             "The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.")]

        // second input contains 0 bad words, so actual result should be same
        [TestCase("The weather in Manchester in winter is sunny. It must be nice for people visiting.",
            "The weather in Manchester in winter is sunny. It must be nice for people visiting.")]
        public void FilterNegativeWords_ShouldReturn_FilteredText_ForThePhrase_ContainingNegativeWords(string phrase, string filteredPhrase)
        {
            // arrange
            // arrange
            var textAnalyserService = new TextAnalyserService();

            var negativeWords = new[] { "swine", "bad", "nasty", "horrible" };

            // act
            var filteredContent = textAnalyserService.FilterNegativeWords(phrase, negativeWords);

            // assert
            filteredContent.ShouldBe(filteredPhrase);
        }
    }
}