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
    public class Reviews
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId id { get; set; }
        [BsonElement]
        public string Review { get; set; }
        [BsonElement]
        public string NameUs { get; set; }

        public Reviews(string rev, string nameus)
        {
            Review = rev;
            NameUs = nameus;
        }
        public async static void AddReview(Reviews rev)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var collection = db.GetCollection<Reviews>("reviews");
            await collection.InsertOneAsync(rev);
        }

        public async static Task<List<Reviews>> GetInfoReview()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var collection = db.GetCollection<Reviews>("reviews");
            return collection.Find(x => true).ToList();
        }
    }
}
