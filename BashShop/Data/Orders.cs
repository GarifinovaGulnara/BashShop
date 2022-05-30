using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashShop.Data
{
    public class Orders
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId id { get; set; }
        [BsonElement]
        public string NameProd { get; set; }
        [BsonElement]
        public double PriceProds { get; set; }
        [BsonElement]
        public string DesProd { get; set; }
        [BsonElement]
        public int Count { get; set; }
        [BsonElement]
        public string NameUser { get; set; }
        [BsonElement]
        public string PhoneUser { get; set; }

        public Orders(string name, double price, string desprod, int count, string nameus, string phoneus)
        {
            NameProd = name;
            PriceProds = price;
            DesProd = desprod;
            Count = count;
            NameUser = nameus;
            PhoneUser = phoneus;
        }
        public async static void AddOrder(Orders or)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var collection = db.GetCollection<Orders>("orders");
            await collection.InsertOneAsync(or);
        }

        public async static Task<List<Orders>> GetInfoOrder()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var collection = db.GetCollection<Orders>("orders");
            return collection.Find(x => x.PhoneUser == App.user.Phone).ToList();
        }
        public async static Task<List<Orders>> GetInfoAllOrders()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var collection = db.GetCollection<Orders>("orders");
            return collection.Find(x => true).ToList();
        }

        public static void DeleteOrder(Orders order)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var collection = db.GetCollection<Orders>("orders");
            collection.DeleteOne(x=>x.id == order.id);
        }
    }
}
