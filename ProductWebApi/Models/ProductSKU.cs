namespace ProductWebApi.Models
{
    public class ProductSKU
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public required List<Sku> Skus { get; set; }    }
}
