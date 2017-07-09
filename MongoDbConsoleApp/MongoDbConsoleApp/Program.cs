using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace MongoDbConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateEmployee("ibrahim", "oğuz", "Batıkent", "Ankara", "123123123");
            Console.ReadLine();
        }

        private static void CreateEmployee(string firstName, string lastName, string address, string city, string departmentId)
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017"));
            var client = new MongoClient(settings);
            var database = client.GetDatabase("demoDB");

            IMongoCollection<BsonDocument> employees = database.GetCollection<BsonDocument>("Employees");
            BsonDocument employee = new BsonDocument {
                        { "FirstName", firstName },
                        { "LastName", lastName },
                        { "Address", address },
                        { "City", city },
                        { "DepartmentId", departmentId }
                        };

            employees.InsertOne(employee);
        }
    }

    class Employee
    {
        public ObjectId _id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public ObjectId DepartmentId { get; set; }
    }
}
