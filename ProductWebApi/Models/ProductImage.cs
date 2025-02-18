namespace ProductWebApi.Models
{
    public class ProductImage
    {
        public int Id { get; set; }

        public required string ImageUrl { get; set; }

        public bool IsPrimary { get; set; }
    }
}
