using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB_Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("dotnet-core-sample");

            var collection = db.GetCollection<Album>("albums");
            collection.InsertOne(new Album
            {
                Title = "Bad",
                Artist = "Michael Jackson",
                Year = 1987
            });
        }
    }

    public class Album
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
    }
}
