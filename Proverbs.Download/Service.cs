namespace Proverbs.Download
{
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
}