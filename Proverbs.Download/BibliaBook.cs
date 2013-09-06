using System.Collections.Generic;

namespace Proverbs.Download
{
    public class BibliaBook
    {
        public string Passage { get; set; }
        public IEnumerable<BibliaChapter> Chapters { get; set; } 
    }
}