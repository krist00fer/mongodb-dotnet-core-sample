using System;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            
            var db = client.GetDatabase("profiles");

            var collection = db.GetCollection<Player>("players");
            
            // DEMO, remove all previous players if there are any
            collection.DeleteMany(p => true);


            collection.InsertOne(new Player
            {
                Gamertag = "krist00fer",
                Location = "Sweden",
                OtherPreference = "Meatballs"
            });

            Console.WriteLine("First player inserted");

            collection.InsertOne(new Player
            {
                Gamertag = "livkl",
                Location = "Germany",
                OtherPreference = "Sauerkraut"
            });

            Console.WriteLine("Second player inserted");

            Console.WriteLine();
            Console.WriteLine("Querying players from Germany");

            var germanPlayers = collection.Find(p => p.Location == "Germany").ToList();

            foreach (var player in germanPlayers)
            {
                Console.WriteLine($"Gamertag: {player.Gamertag} has special preference of: {player.OtherPreference}");
            }
            Console.WriteLine();
        }
    }

    public class Player
    {
        [BsonId]
        public string Gamertag { get; set; }
        public string Location { get; set; }
        public string OtherPreference { get; set; }
    }
}
