using System;

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
            Console.ReadLine();
        }
    }
}
