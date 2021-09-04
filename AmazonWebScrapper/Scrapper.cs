using AmazonWebScrapper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonWebScrapper
{
    public class Scraper
    {
        private readonly IHtmlDocumentLoader _htmlloader;

        //TODO: Use interfaces and iject those field via the constructor
        ProductPageScaper _pageScrapper = new ProductPageScaper();
        ProductListScraper _productListScrapper = new ProductListScraper();
        ProductScraper _productScrapper = new ProductScraper();

        public Scraper(IHtmlDocumentLoader htmlloader)
        {
            this._htmlloader = htmlloader;
        }

        public IEnumerable<Product> ExtractProducts(string url)
        {
            HtmlAgilityPack.HtmlDocument html = _htmlloader.LoadDocumentFromUrl(url);
            IEnumerable<HtmlAgilityPack.HtmlNode> htmlProductLists = _pageScrapper.ReadProductLists(html);
            foreach (HtmlAgilityPack.HtmlNode htmlProductList in htmlProductLists)
            {
                IEnumerable<HtmlAgilityPack.HtmlNode> productNodes = _productListScrapper.ReadProductsHtml(htmlProductList);
                foreach (HtmlAgilityPack.HtmlNode productNode in productNodes)
                {
                    Product product = _productScrapper.ReadProduct(productNode);
                    yield return product;
                }
            }
        }
    }
}
