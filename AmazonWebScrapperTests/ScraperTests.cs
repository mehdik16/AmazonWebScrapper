using NUnit.Framework;
using Moq;
using System.Linq;
using FluentAssertions;

namespace AmazonWebScrapper.Tests
{
    [TestFixture()]
    public class ScraperTests
    {
        Scraper scraper;
        
        public ScraperTests()
        {
            Mock<IHtmlDocumentLoader> mockHtmlLoader = new Mock<IHtmlDocumentLoader>();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(AmazonWebScraperTests.TestFixtures.Amazon_Headphone_Html);
            mockHtmlLoader.Setup((loader) => loader.LoadDocumentFromUrl(It.IsAny<string>())).Returns(doc);
            scraper = new Scraper(mockHtmlLoader.Object);
        }

        [Test()]
        public void ExtractProductsTest()
        {
            var returnedPoducts = scraper.ExtractProducts("").ToArray();
            returnedPoducts.Should().NotBeEmpty().And.HaveCount(33).And.OnlyContain(p => !string.IsNullOrEmpty(p.Asin));
           
        }
    }
}