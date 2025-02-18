namespace ProductWebApi.Models
{
    public class Product
    {
        public int Id { get; set; }

        public required string Description { get; set; }

        public required string Name { get; set; }

        public required string Color { get; set; }

        public double Price { get; set; }

        public double BasePrice { get; set; }

        public bool IsAvailable { get; set; }

        public List<string> Tags { get; set; } = [];

        public required List<string> Category { get; set; }

        public required string Brand { get; set; }

        public required List<ProductImage> Images { get; set; }

        public bool IsColorVariantAvailable { get; set; }

        public List<ProductColorVariant> Colors { get; set; } = [];

        public required string Sku { get; set; }

        public required List<string> Sizes { get; set; }

    }
}
