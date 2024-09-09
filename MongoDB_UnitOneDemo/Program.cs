using DotNetEnv;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MongoDB_UnitOneDemo;

//Task-1

/*var mongoURL = new MongoUrl("mongodb+srv://myAtlasDBUser:MongoParol123@myatlasclusteredu.vqhvw.mongodb.net/");
var client = new MongoClient(mongoURL);

var dbList = client.ListDatabases().ToList();

Console.WriteLine("The list of databases on this server is: ");
foreach (var db in dbList)
{
    Console.WriteLine(db);
}
*/

namespace MongoDBExample
{
    public class Transfer
    {
       
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BsonSerializer.RegisterSerializer(new DecimalSerializer(BsonType.Decimal128));

                Env.TraversePath().Load();
                var connectionString = Environment.GetEnvironmentVariable("mongodb+srv://myAtlasDBUser:MongoParol123@myatlasclusteredu.vqhvw.mongodb.net/");

                var settings = MongoClientSettings.FromConnectionString(connectionString);
                var client = new MongoClient(settings);

                var database = client.GetDatabase("bank");
                var accountsCollection = database.GetCollection<Account>("accounts");
                var transfersCollection = database.GetCollection<Transfer>("transfers");

                var sampleDocument = new Account
                {
                    AccountId = "MDB829001337",
                    AccountHolder = "Linus Torvalds",
                    AcountType = "checking",
                    Balance = 50352434,
                };

                // Insert a single document into the `accounts` collection
                accountsCollection.InsertOne(sampleDocument);
                Console.WriteLine("Successfully inserted a document into the `accounts` collection!");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}