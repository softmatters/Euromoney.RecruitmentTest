using System.Collections.Generic;

namespace ContentConsole
{
    /// <summary>
    /// TextAnalyser interface to analyse text, detecting and filtering negative words.
    /// </summary>
    public interface ITextAnalyserService
    {
        /// <summary>
        /// Returns the number of negative words in a phrase
        /// </summary>
        /// <param name="phrase"></param>
        /// <param name="negativeWords"></param>
        /// <returns></returns>
        int GetNegativeWordsCount(string phrase, IEnumerable<string> negativeWords);
    }
}