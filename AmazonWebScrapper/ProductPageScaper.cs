using AmazonWebScrapper.Entities;
using System.Collections.Generic;

namespace AmazonWebScrapper
{
    public class ProductPageScaper
    {
        public IEnumerable<HtmlAgilityPack.HtmlNode> ReadProductLists(HtmlAgilityPack.HtmlDocument html)
        {
            string listXPath = @"//div[@class=""s-main-slot s-result-list s-search-results sg-row""]";//@"//*[@id=""search""]/div[1]/div[1]/div/span[3]/div[2]";
            foreach (var listNode in html.DocumentNode.SelectNodes(listXPath))
            {
                yield return listNode;
            }
        }
    }
}
