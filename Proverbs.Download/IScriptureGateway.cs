namespace Proverbs.Download
{
    public interface IScriptureGateway
    {
        Book GetBook(string bookName);
    }
}