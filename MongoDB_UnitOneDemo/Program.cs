using MongoDB.Driver;

var mongoURL = new MongoUrl("mongodb+srv://myAtlasDBUser:MongoParol123@myatlasclusteredu.vqhvw.mongodb.net/");
var client = new MongoClient(mongoURL);

var dbList = client.ListDatabases().ToList();

Console.WriteLine("The list of databases on this server is: ");
foreach (var db in dbList)
{
    Console.WriteLine(db);
}