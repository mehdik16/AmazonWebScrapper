using AmazonWebScrapper.Entities;

namespace AmazonWebScrapper
{
    public class ProductScraper : IProductScraper
    {
        public Product ReadProduct(HtmlAgilityPack.HtmlNode htmlProductNode)
        {
            var result = new Product();
            PopulateAsin(htmlProductNode, result);
            PopulateDescriptionAndUrl(htmlProductNode, result);
            PopulatePrice(htmlProductNode, result);

            return result;
        }

        private void PopulateAsin(HtmlAgilityPack.HtmlNode htmlNode, Product product)
        {
            product.Asin = htmlNode.GetAttributeValue("data-asin", "");
        }

        private void PopulateDescriptionAndUrl(HtmlAgilityPack.HtmlNode htmlNode, Product product)
        {
            string xpath = @"//a[@class=""a-link-normal a-text-normal""]";
            var linkNode = htmlNode.SelectSingleNode(xpath);
            product.DetailsUrl = linkNode.GetAttributeValue("href", "");
            var descriptionNode = linkNode.ChildNodes.FindFirst("span");
            if (descriptionNode != null)
            {
                product.Description = descriptionNode.InnerHtml;
            }
        }


        private void PopulatePrice(HtmlAgilityPack.HtmlNode htmlNode, Product product)
        {
            string xpath = @"//span[@class=""a-price-symbol""]";
            var priceSymbolNode = htmlNode.SelectSingleNode(xpath);
            product.PriceCurrencySymbol = priceSymbolNode.InnerHtml;

            xpath = @"//span[@class=""a-price-whole""]";
            var priceWholeNode = htmlNode.SelectSingleNode(xpath);
            xpath = @"//span[@class=""a-price-fraction""]";
            var priceDecimalNode = htmlNode.SelectSingleNode(xpath);
            string fullPrice = $"{priceWholeNode.InnerText}{priceDecimalNode.InnerText}";
            decimal parsedDecimal;
            if(decimal.TryParse(fullPrice, out parsedDecimal))
            {
                product.Price = parsedDecimal;
                return;
            }
        }
    }
}
