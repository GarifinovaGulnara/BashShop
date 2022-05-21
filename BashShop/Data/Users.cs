using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace BashShop.Data
{
    public class Users
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId id { get; set; }
        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        public string Surname { get; set; }
        [BsonElement]
        public string Patronic { get; set; }
        [BsonElement]
        public string DateBirth { get; set; }
        [BsonElement]
        public string Phone { get; set; }
        [BsonElement]
        public string Pass { get; set; }
        [BsonElement]
        public bool IsAdmin { get; set; }

        public Users(string name, string surname, string patronic, string datebirth, string phone, string pass, bool isadmin)
        {
            Name = name;
            Surname = surname;
            Patronic = patronic;
            DateBirth = datebirth;
            Phone = phone;
            Pass = pass;
            IsAdmin = isadmin;
        }

        public Users(string phone, string pass)
        {
            Phone = phone;
            Pass = pass;
        }

        public async static void AddUser(Users user)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var collection = db.GetCollection<Users>("users");
            await collection.InsertOneAsync(user);
        }

        public static bool LogInUser(Users user)
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var collection = db.GetCollection<Users>("users");
            var users = collection.Find(x => true).ToList();
            App.user = users.Where(x => x.Phone == user.Phone && x.Pass == user.Pass).FirstOrDefault();
            if (App.user == null)
                return false;
            return true;
        }
    }
}
