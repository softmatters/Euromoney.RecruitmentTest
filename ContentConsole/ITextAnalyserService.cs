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

        /// <summary>
        /// Filter the negative words and masked them e.g. horrible will be masked to h#####e
        /// </summary>
        /// <param name="content"></param>
        /// <param name="negativeWords"></param>
        /// <returns></returns>
        string FilterNegativeWords(string content, IEnumerable<string> negativeWords);
    }
}