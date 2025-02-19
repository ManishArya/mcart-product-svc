using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace ProductWebApi.Cosmos
{
    public class DataAccessClient
    {
        private readonly CosmosClient _client;

        public DataAccessClient(IOptions<DataAccessClientSettings> options)
        {
            var cosmosSettings = options.Value;
            _client = new CosmosClient(cosmosSettings.ConnectionString, new CosmosClientOptions()
            {
                ConnectionMode = ConnectionMode.Gateway,
                SerializerOptions = new CosmosSerializationOptions() { PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase }
            });
        }

        public CosmosClient Client { get { return _client; } }
    }
}
