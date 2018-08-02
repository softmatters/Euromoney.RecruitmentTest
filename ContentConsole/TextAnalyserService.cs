using System.Collections.Generic;
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
    }
}