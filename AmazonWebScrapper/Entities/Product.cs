namespace AmazonWebScrapper.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DetailsUrl { get; set; }
        public decimal Price { get; set; }
        public string PriceCurrencySymbol { get; set; }
        public string Asin { get; set; }
    }
}
