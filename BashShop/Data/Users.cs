using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Linq;
using MongoDB.Driver;

namespace BashShop.Data
{
    public class Users
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
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
        public byte[] Photo { get; set; }
        [BsonElement]
        public bool IsAdmin { get; set; }
        public Users(string name, string surname, string patronic, string datebirth, string phone, string pass, byte[] photo, bool isadmin = false)
        {
            Name = name;
            Surname = surname;
            Patronic = patronic;
            DateBirth = datebirth;
            Phone = phone;
            Pass = pass;
            IsAdmin = isadmin;
            Photo = photo;
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

        public static void EditProfile()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("BashShop");
            var data = db.GetCollection<Users>("users");
            var UpdateDef = Builders<Users>.Update.Set("Name", App.user.Name).Set("Surname", App.user.Surname).Set("Patronic", App.user.Patronic).Set("Phone", App.user.Phone).Set("Pass", App.user.Pass);
            data.UpdateOne(basa => basa.Id == App.user.Id, UpdateDef);
            
        }

        public void Update()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("ReabilitionCenter");
            var collection = db.GetCollection<Users>("users");
            var UpdateDef = Builders<Users>.Update.Set("Photo", App.user.Photo);
            collection.UpdateOne(basa => basa.Id == App.user.Id, UpdateDef);
        }
    }
}
