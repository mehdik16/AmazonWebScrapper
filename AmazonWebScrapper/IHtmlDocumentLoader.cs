namespace AmazonWebScrapper
{
    public interface IHtmlDocumentLoader
    {
        HtmlAgilityPack.HtmlDocument LoadDocumentFromUrl(string url);
    }
}