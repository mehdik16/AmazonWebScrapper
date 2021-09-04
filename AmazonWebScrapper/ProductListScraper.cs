using AmazonWebScrapper.Entities;
using System.Collections.Generic;

namespace AmazonWebScrapper
{
    public class ProductListScraper
    {
        public IEnumerable<HtmlAgilityPack.HtmlNode> ReadProductsHtml(HtmlAgilityPack.HtmlNode htmlProductList)
        {
            string listXPath = @"//div[@data-asin and string-length(@data-asin)!=0]";
            foreach (var productNode in htmlProductList.SelectNodes(listXPath))
            {
                yield return productNode;
            }
        }
    }
}
