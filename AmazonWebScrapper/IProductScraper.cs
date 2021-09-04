using AmazonWebScrapper.Entities;

namespace AmazonWebScrapper
{
    public interface IProductScraper
    {
        Product ReadProduct(HtmlAgilityPack.HtmlNode htmlProductNode);
    }
}