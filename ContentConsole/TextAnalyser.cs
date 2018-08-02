using System;

namespace ContentConsole
{
    public class TextAnalyser
    {
        private readonly ITextAnalyserService _textAnalyserService;

        public TextAnalyser(ITextAnalyserService textAnalyserService)
        {
            _textAnalyserService = textAnalyserService;
        }

        public void Start()
        {
            // define list of negative words
            var badWords = new[] { "swine", "bad", "nasty", "horrible" };

            var content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var badWordsCount = _textAnalyserService.GetNegativeWordsCount(content, badWords);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine($"Total Number of negative words:{badWordsCount}");

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }
}