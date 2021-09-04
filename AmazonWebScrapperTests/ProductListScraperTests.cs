using AmazonWebScrapper;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace AmazonWebScrapper.Tests
{
    [TestFixture()]
    public class ProductListScraperTests
    {
        ProductListScraper productListScrapper = new ProductListScraper();

        [Test()]
        public void ReadProductsHtmlTest()
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(AmazonWebScraperTests.TestFixtures.Amazon_Headphone_ProductList_Html);
            HtmlAgilityPack.HtmlNode node = doc.DocumentNode;
            var returnedProductNodes = productListScrapper.ReadProductsHtml(node).ToArray();

            returnedProductNodes.Should().HaveCount(33);

        }
    }
}