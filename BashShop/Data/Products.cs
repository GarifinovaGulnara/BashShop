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

        public static void DeleteProd(Products prod)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var collection = db.GetCollection<Products>("prods");
            collection.DeleteOne(x => x.Id == prod.Id);
        }
        public static void EditProd()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var data = db.GetCollection<Products>("prods");
            var UpdateDef = Builders<Products>.Update.Set("Name", App.products.Name).Set("Description", App.products.Description).Set("Price", App.products.Price);
            data.UpdateOne(basa => basa.Id == App.products.Id, UpdateDef);
        }

        public static async Task<List<Products>> SearchList(string word)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var collection = db.GetCollection<Products>("prods");
            return collection.Find(x => x.Name == word).ToList();
        }

        public static async Task<List<Products>> SortingList()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var collection = db.GetCollection<Products>("prods");
            //return collection.Find(x => true).Sort("prods":1, sort).ToList();
            var w = from c in collection.AsQueryable<Products>()
                    orderby c.Price
                    select c;
            return w.ToList();
        }
        public static async Task<List<Products>> SortingLisrMinus()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var collection = db.GetCollection<Products>("prods");
            //return collection.Find(x => true).Sort("prods":1, sort).ToList();
            var w = from c in collection.AsQueryable<Products>()
                    orderby c.Price descending
                    select c;
            return w.ToList();
        }
    }
}
