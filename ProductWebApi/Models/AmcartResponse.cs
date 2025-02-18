namespace ProductWebApi.Models
{
    public class AmcartResponse<T> : AmcartResponseState
    {
        public T? Content { get; set; }
    }
}
