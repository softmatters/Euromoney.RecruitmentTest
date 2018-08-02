using System.Collections.Generic;

namespace ContentConsole
{
    public class WordsRepository : IWordsRepository
    {
        /// <summary>
        /// List to add the negative words
        /// </summary>
        public List<string> NegativeWords { get; set; }

        public WordsRepository()
        {
            NegativeWords = new List<string> { "swine", "bad", "nasty", "horrible" };
        }

        /// <summary>
        /// Gets the list of negative words from the database
        /// </summary>
        /// <returns>Returns the list of negative words</returns>
        public IEnumerable<string> GetNegativeWords()
        {
            return NegativeWords;
        }
    }
}