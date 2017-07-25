using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MyWebApi.Models;
using Microsoft.Extensions.Options;

namespace MyWebApi.DataProviders
{
    public class MongoOrderDataProvider
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        private IMongoCollection<Order> _collection;

        public MongoOrderDataProvider(string connectionString)
        {

            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase("test");
            _collection = _database.GetCollection<Order>("orders");
        }

        public async Task<string> InsertOrder(Order order)
        {
            string id = Guid.NewGuid().ToString();
            order.Id = id;
            await _collection.InsertOneAsync(order);
            return id;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Order> GetOrder(string id)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.Id, id);
            List<Order> orders = await _collection.Find(filter).ToListAsync();
            return orders.FirstOrDefault();
        }
    }
}
