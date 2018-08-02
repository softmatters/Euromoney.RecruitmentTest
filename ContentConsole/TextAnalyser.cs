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

            Console.WriteLine("Please enter the choice:");
            Console.WriteLine("1: show the original phrase with negative words count");
            Console.WriteLine("2: filter out the negative words");
            Console.WriteLine("");

            var input = Console.ReadLine();

            while (true)
            {
                if (string.IsNullOrEmpty(input) || !(input.Equals("1") || input.Equals("2")))
                {
                    Console.WriteLine("Invalid Selection");
                    continue;
                }

                break;
            }

            // factory can be used to inject a masking analyser, but just to keep it simple
            // using switch statment
            switch (input)
            {
                case "1":
                    var badWordsCount = GetNegativeWordsCount(content);
                    Console.WriteLine("Scanned the text:");
                    Console.WriteLine(content);
                    Console.WriteLine($"Total Number of negative words:{badWordsCount}");
                    break;

                case "2":
                    var filteredContent = FilterNegativeWords(content);
                    Console.WriteLine("Scanned the text:");
                    Console.WriteLine(filteredContent);
                    break;
            }

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

        /// <summary>
        /// Filter the negative words
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string FilterNegativeWords(string content)
        {
            // get the list of negative words
            var badWords = _wordsRepository.GetNegativeWords();

            // filter negative words
            var filterdString = _textAnalyserService.FilterNegativeWords(content, badWords);

            return filterdString;
        }
    }
}