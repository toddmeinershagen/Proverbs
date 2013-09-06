using System.Collections.Generic;

namespace Proverbs.Download
{
    public class Book
    {
        public string Title { get; set; }
        public List<Verse> Verses { get; set; }
    }
}