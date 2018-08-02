using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ContentConsole
{
    /// <summary>
    /// TextAnalyser implemenation to analyse text, detecting and filtering negative words.
    /// </summary>
    public class TextAnalyserService : ITextAnalyserService
    {
        /// <summary>
        /// Returns the number of negative words in a phrase
        /// </summary>
        /// <param name="phrase"></param>
        /// <param name="negativeWords"></param>
        /// <returns></returns>
        public int GetNegativeWordsCount(string phrase, IEnumerable<string> negativeWords)
        {
            // convert the negative words to a regex expression
            var expression = $"({string.Join("|", negativeWords)})";

            var matches = Regex.Matches(phrase, expression);

            return matches.Count;
        }

        /// <summary>
        /// Filter the negative words and masked them e.g. horrible will be masked to h#####e
        /// </summary>
        /// <param name="phrase"></param>
        /// <param name="negativeWords"></param>
        /// <returns></returns>
        public string FilterNegativeWords(string phrase, IEnumerable<string> negativeWords)
        {
            // convert the negative words to a regex expression
            var expression = $"({string.Join("|", negativeWords)})";

            var matches = Regex.Matches(phrase, expression);

            // if we have match, mask the contetns
            if (matches.Count > 0)
            {
                phrase = Regex.Replace(phrase, expression, match =>
                {
                    var result = match.ToString();
                    var firstChar = result.First();
                    var lastChar = result.Last();

                    var mask = new string('#', result.Length - 2);

                    return $"{firstChar}{mask}{lastChar}";
                });
            }

            return phrase;
        }
    }
}