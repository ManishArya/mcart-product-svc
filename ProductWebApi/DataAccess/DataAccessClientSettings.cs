namespace ProductWebApi.Cosmos
{
    public class DataAccessClientSettings
    {
        public required string ConnectionString { get; set; }

        public required string DatabaseName { get; set; }

        public required string ProductContainerName { get; set; }

        public string SkuContainerName { get; set; } = string.Empty;
    }
}
