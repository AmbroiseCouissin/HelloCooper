using System.Threading.Tasks;
using HelloCooper.Models;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace HelloCooper.Repositories
{
    public class MongoDbHelloMessageRepository : IHelloMessageRepository
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<MongoDbCustomMessage> _collection;

        public MongoDbHelloMessageRepository(
            IMongoClient client,
            string databaseName,
            string collectionName)
        {
            _client = client;
            _database = client.GetDatabase(databaseName);
            _collection = _database.GetCollection<MongoDbCustomMessage>(collectionName);
        }

        public async Task<CustomMessage> GetCustomHelloMessageAsync(string messageId)
        {
            MongoDbCustomMessage mongoMessage = await (await _collection.FindAsync<MongoDbCustomMessage>(
                Builders<MongoDbCustomMessage>.Filter.Eq("Id", messageId)
            )).FirstOrDefaultAsync();

            return new CustomMessage
            {
                Id = mongoMessage.Id,
                Message = mongoMessage.Message
            };
        }

        public async Task CreateCustomHelloMessageAsync(CustomMessage customMessage)
        {
            var mongoMessage = new MongoDbCustomMessage
            {
                Id = customMessage.Id,
                Message = customMessage.Message
            };

            await _collection.InsertOneAsync(mongoMessage);
        }

        private class MongoDbCustomMessage
        {
            [BsonId]
            public string Id { get; set; }
            public string Message { get; set; }
        }
    }

}
