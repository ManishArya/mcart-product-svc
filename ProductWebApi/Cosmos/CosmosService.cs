using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace ProductWebApi.Cosmos
{
    public class CosmosService
    {
        private readonly CosmosSettings _cosmosSettings;
        private readonly Container _container;

        public CosmosService(IOptions<CosmosSettings> options)
        {
            _cosmosSettings = options.Value;

            var cosmosClient = new CosmosClient(_cosmosSettings.Endpoint, _cosmosSettings.Key);
            _container = cosmosClient.GetContainer("DatabaseId", "ContainerId");
        }

        public Container container => _container;
    }
}
