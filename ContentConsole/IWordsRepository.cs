using System.Collections.Generic;

namespace ContentConsole
{
    public interface IWordsRepository
    {
        List<string> NegativeWords { get; set; }

        IEnumerable<string> GetNegativeWords();
    }
}