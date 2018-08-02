using System;

namespace ContentConsole
{
    public class TextAnalyser
    {
        private readonly ITextAnalyserService _textAnalyserService;
        private readonly IWordsRepository _wordsRepository;

        public TextAnalyser(ITextAnalyserService textAnalyserService, IWordsRepository wordsRepository)
        {
            _textAnalyserService = textAnalyserService;
            _wordsRepository = wordsRepository;
        }

        public void Start()
        {
            var content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var badWordsCount = GetNegativeWordsCount(content);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine($"Total Number of negative words:{badWordsCount}");

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// Gets the negative words count using the repository
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public int GetNegativeWordsCount(string content)
        {
            // get the list of negative words
            var badWords = _wordsRepository.GetNegativeWords();

            // get the count of negative words
            var badWordsCount = _textAnalyserService.GetNegativeWordsCount(content, badWords);

            return badWordsCount;
        }
    }
}