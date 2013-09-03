using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Proverbs.Download
{
    public class VerseParser
    {
        public List<Verse> Parse(string text)
        {
            const string pattern = @"\[.*\]";
            var substrings = Regex.Split(text, pattern);
            var openingBracketIndex = text.IndexOf('[');
            var colonIndex = text.IndexOf(':');
            var closingBracketIndex = text.IndexOf(']');
            var chapter = text.Substring(openingBracketIndex + 1, colonIndex - openingBracketIndex - 1);
            var startingChapter = Convert.ToInt16(chapter);
            var verse = text.Substring(colonIndex + 1, closingBracketIndex - colonIndex - 1);
            var startingVerse = Convert.ToInt16(verse);

            var verses = (from match in substrings
                          where !string.IsNullOrEmpty(match)
                          select new Verse { ChapterNumber = startingChapter, Text = match.Trim(), VerseNumber = startingVerse++ });

            return verses.ToList();
        }
    }
}