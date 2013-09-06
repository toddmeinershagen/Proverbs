using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Proverbs.Download
{
    public class ScriptureGateway : IScriptureGateway
    {
        private readonly string _key;
        private readonly VerseParser _parser;
        private IEnumerable<BibliaBook> _books;
 
        public ScriptureGateway(string key, VerseParser parser)
        {
            _key = key;
            _parser = parser;

            InitializeBooks();
        }

        private void InitializeBooks()
        {
            var url = string.Format("http://api.biblia.com/v1/bible/contents/LEB.txt.json?key={0}", "fd37d8f28e95d3be8cb4fbc37e15e18e");
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;

                    dynamic context = JObject.Parse(responseString);
                    _books = JsonConvert.DeserializeObject<IEnumerable<BibliaBook>>(context.books.ToString());
                }
            }
        }

        public Book GetBook(string bookName)
        {
            var bookTableOfContents = _books.FirstOrDefault(b => b.Passage == bookName);
            var book = new Book {Title = bookName};
            book.Verses = new List<Verse>();

            var counter = 1;
            foreach (var chapter in bookTableOfContents.Chapters)
            {
                var url =
                    string.Format(
                        "http://www.esvapi.org/v2/rest/passageQuery?key={0}&passage={1}&output-format=plain-text&include-heading-horizontal-lines=false&include-headings=false&include-footnotes=false&include-passage-references=false&include-verse-numbers=true&include-first-verse-numbers=true&include-passage-horizontal-lines=false",
                        _key,
                        chapter.Passage.Replace(" ", ""));
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        string responseString = responseContent.ReadAsStringAsync().Result.Trim();

                        book.Verses.AddRange(_parser.Parse(responseString));
                    }
                }
            }
            
            return book;
        }
    }
}