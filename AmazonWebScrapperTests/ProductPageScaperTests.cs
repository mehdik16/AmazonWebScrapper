using NUnit.Framework;
using System.Linq;

namespace AmazonWebScrapper.Tests
{
    [TestFixture()]
    public class ProductPageScaperTests
    {
        private ProductPageScaper scrapper = new ProductPageScaper();

        [Test()]
        public void ReadProductListsTest()
        {
            string testHtml = AmazonWebScraperTests.TestFixtures.Amazon_Headphone_Html;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(testHtml);

            var returnedLists = scrapper.ReadProductLists(doc).ToArray();

            Assert.AreEqual(1, returnedLists.Length);
            Assert.AreEqual("s-main-slot s-result-list s-search-results sg-row", returnedLists[0].GetAttributeValue("class",""));
        }
    }
}