using Moq;
using NUnit.Framework;
using Shouldly;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    internal class Story2Tests
    {
        [TestCase("This is a phrase", 5)]
        [TestCase("This is another phrase", 3)]
        public void GetNegativeWordsCount_UsingRepositoryMock_ShouldReturn_CorrectCount_ForThePhrase(string phrase, int expectedNegativeWords)
        {
            // arrange
            // using mocks repository to create multiple mocks
            var mocks = new MockRepository(MockBehavior.Strict);
            var wordsRepository = mocks.Create<IWordsRepository>(MockBehavior.Loose);
            var textAnalyser = mocks.Create<ITextAnalyserService>();

            wordsRepository.Setup(repo => repo.GetNegativeWords()).Returns(It.IsAny<string[]>());
            textAnalyser.Setup(m => m.GetNegativeWordsCount(phrase, It.IsAny<string[]>())).Returns(expectedNegativeWords);

            var analyser = new TextAnalyser(textAnalyser.Object, wordsRepository.Object);

            // act
            var result = analyser.GetNegativeWordsCount(phrase);
            result.ShouldBe(expectedNegativeWords);
            mocks.VerifyAll();
        }

        [Test]
        public void GetNegativeWordsCount_UsingWordsFromRepository_ShouldReturn_CorrectCount_ForThePhrase()
        {
            // arrange
            // using mocks repository to create multiple mocks
            var mocks = new MockRepository(MockBehavior.Strict);
            var wordsRepository = mocks.Create<IWordsRepository>(MockBehavior.Loose);
            var textAnalyser = mocks.Create<ITextAnalyserService>();

            var badWords = new[] { "some", "bad", "words" };

            wordsRepository.Setup(repo => repo.GetNegativeWords()).Returns(badWords);
            textAnalyser.Setup(m => m.GetNegativeWordsCount(It.IsAny<string>(), badWords)).Returns(5);

            // act
            var analyser = new TextAnalyser(textAnalyser.Object, wordsRepository.Object);

            // assert
            var result = analyser.GetNegativeWordsCount("input phrase");

            result.ShouldBe(5);
            mocks.VerifyAll();
        }
    }
}