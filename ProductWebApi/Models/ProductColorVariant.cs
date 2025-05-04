namespace ProductWebApi.Models
{
    public class ProductColorVariant
    {
        public int id { get; set; }

        public int ProductId { get; set; }

        public required string ColorName { get; set; }

        public required string ColorCode { get; set; }
    }
}
