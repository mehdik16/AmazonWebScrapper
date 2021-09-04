using NUnit.Framework;
using AmazonWebScrapper.Entities;
using FluentAssertions;

namespace AmazonWebScrapper.Tests
{
    [TestFixture()]
    public class ProductScraperTests
    {
        ProductScraper scraper = new ProductScraper();
        [Test()]
        public void ReadProductTest()
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(AmazonWebScraperTests.TestFixtures.Amazon_Headphone_Product_Html);
            HtmlAgilityPack.HtmlNode node = doc.DocumentNode.FirstChild;
            Product product = scraper.ReadProduct(node);

            product.Should().Match<Product>(p => p.Asin == "B098QSLZNQ")
                .And.Match<Product>(p => p.Price == 19.99m)
                .And.Match<Product>(p => p.PriceCurrencySymbol == "£")
                .And.Match<Product>(p => p.Description == "Bluetooth Headphones, Bluetooth Earbuds Sports Earphones, 14H Playtime/HD Stereo Sound with cVc 8.0 Noise Reduction Mic Magnetic In Ear Wireless Headphones IPX7 Waterproof for Running Sports")
                .And.Match<Product>(p => p.DetailsUrl == "/gp/slredirect/picassoRedirect.html/ref=pa_sp_atf_browse_electronics_sr_pg1_1?ie=UTF8&amp;adId=A01834711VKBYREK5TG6E&amp;url=%2FBluetooth-Headphones-Earphones-Reduction-Waterproof%2Fdp%2FB098QSLZNQ%2Fref%3Dsr_1_1_sspa%3Fdchild%3D1%26qid%3D1630757672%26s%3Delectronics%26sr%3D1-1-spons%26psc%3D1&amp;qualifier=1630757672&amp;id=8390425074240979&amp;widgetName=sp_atf_browse");
        }
    }
}