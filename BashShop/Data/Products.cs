using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BashShop.Data
{
    public class Products
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        public string Description { get; set; }
        [BsonElement]
        public double Price { get; set; }

        public Products(string name, string des, double price)
        {
            Name = name;
            Description = des;
            Price = price;
        }

        public async static void AddProd(Products prod)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var collection = db.GetCollection<Products>("prods");
            await collection.InsertOneAsync(prod);
        }
        
        public async static Task<List<Products>> GetProd()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var collection = db.GetCollection<Products>("prods");
            return collection.Find(x => true).ToList();
        }

        public void DeleteProd()
        {
            try
            {
                MongoClient client = new MongoClient();
                var db = client.GetDatabase("BashShop");
                var collection = db.GetCollection<Products>("prods");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
