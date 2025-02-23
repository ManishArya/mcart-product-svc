namespace ProductWebApi.Models
{
    public class Sku
    {
        public int Id { get; set; }

        public int SkuId { get; set; }

        public required string Size { get; set; }

        public bool Available { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public double BasePrice { get; set; }

        public int Quantity { get; set; }

    }
}
