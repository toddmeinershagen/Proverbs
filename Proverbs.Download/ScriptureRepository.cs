using System;

namespace Proverbs.Download
{
    public class ScriptureRepository : IScriptureRepository
    {
        public void Save(Book book)
        {
            //const string connectionString = "";
            //using (IDbConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    var rowCount = connection.Execute(@"insert MyTable(colA, colB) values (@a, @b)", book.Verses);
            //    Trace.Assert(rowCount == book.Verses.Count);
            //}

            Console.WriteLine("{0}", book.Title);
            foreach (var verse in book.Verses)
            {
                Console.WriteLine("{0}:{1}", verse.ChapterNumber, verse.VerseNumber);
                Console.WriteLine(verse.Text);
            }
        }
    }
}