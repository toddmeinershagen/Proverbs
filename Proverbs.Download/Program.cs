using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Dapper;

namespace Proverbs.Download
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new VerseParser();
            var gateway = new ScriptureGateway("8eeffb3fb3632fbe", parser);
            var repository = new ScriptureRepository();
            var service = new Service(gateway, repository);
            service.Execute();
        }
    }

    public class Service
    {
        private readonly IScriptureGateway _scriptureGateway;
        private readonly IScriptureRepository _scriptureRepository;

        public Service(IScriptureGateway scriptureGateway, IScriptureRepository scriptureRepository)
        {
            _scriptureGateway = scriptureGateway;
            _scriptureRepository = scriptureRepository;
        }

        public void Execute()
        {
            var book = _scriptureGateway.GetBook("Proverbs");
            _scriptureRepository.Save(book);
        }
    }

    public interface IScriptureGateway
    {
        Book GetBook(string bookName);
    }

    public class ScriptureGateway : IScriptureGateway
    {
        private readonly string _key;
        private readonly VerseParser _parser;

        public ScriptureGateway(string key, VerseParser parser)
        {
            _key = key;
            _parser = parser;
        }

        public Book GetBook(string bookName)
        {
            var text = "";
            var verses = _parser.Parse(text);
            return null;
        }
    }

    public interface IScriptureRepository
    {
        void Save(Book book);
    }

    public class ScriptureRepository : IScriptureRepository
    {
        public void Save(Book book)
        {
            const string connectionString = "";
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var rowCount = connection.Execute(@"insert MyTable(colA, colB) values (@a, @b)", book.Verses);
                Trace.Assert(rowCount == book.Verses.Count);
            }
        }
    }

    public class Book
    {
        public List<Verse> Verses { get; set; }
    }

    public class Verse
    {
        public Int16 ChapterNumber { get; set; }
        public Int16 VerseNumber { get; set; }
        public string Text { get; set; }
    }
}
