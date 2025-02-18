namespace ProductWebApi.Models
{
    public class ProductSKU
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int SkuId { get; set; }

        public required string Size { get; set; }

        public bool IsAvailable { get; set; }

        public required string  Name { get; set; }

        public double Price { get; set; }

        public double BasePrice { get; set; }

        public int Quantity { get; set; }

    }
}
