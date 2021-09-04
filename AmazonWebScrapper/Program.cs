using AmazonWebScrapper.Entities;
using System;
using System.Collections.Generic;

namespace AmazonWebScrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 0: Create a variable to hold the first pages Url
            string urlToScrap = "https://www.amazon.co.uk/s?rh=n%3A4085731&fs=true&ref=lp_4085731_sar";
            //Step 1: Create an instance of WebClient: This class will allow us to retrieve the HTML for a given web page
            System.Net.WebClient wc = new System.Net.WebClient();
            //Step 2: Call the WebClient to retrieve the content of the first page
            string html = wc.DownloadString(urlToScrap);
            // Neext steps:
            //  3. Extract products from this page
            //  4. Extract the URL for the next page and repeat starting from Step 2 with the url for the next page
        }

        static IEnumerable<Product> ExtractProducts(string url)
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument html = web.Load(url);
            ProductPageScaper pageScrapper = new ProductPageScaper();
            ProductListScraper productListScrapper = new ProductListScraper();
            ProductScraper productScrapper = new ProductScraper();
            IEnumerable<HtmlAgilityPack.HtmlNode> htmlProductLists = pageScrapper.ReadProductLists(html);
            foreach (HtmlAgilityPack.HtmlNode htmlProductList in htmlProductLists)
            {
                IEnumerable<HtmlAgilityPack.HtmlNode> productNodes = productListScrapper.ReadProductsHtml(htmlProductList);
                foreach (HtmlAgilityPack.HtmlNode productNode in productNodes)
                {
                    Product product = productScrapper.ReadProduct(productNode);
                    yield return product;
                }
            }
        }
    }
}
