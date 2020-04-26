﻿using Mongo.Migration.Demo.Model;
using Mongo.Migration.Migrations.Database;
using MongoDB.Driver;

namespace Mongo.Migration.Demo.MongoMigrations.Migrations
{
    public class M100_AddNewCar : DatabaseMigration
    {
        public M100_AddNewCar()
            : base("1.0.0")
        {
        }

        public override void Up(IMongoDatabase db)
        {
            var collection = db.GetCollection<Car>("Car");
            collection.InsertOne(new Car
            {
                Doors = 123,
                Type = "AddedInMigration",
                Version = "0.1.1"
            });
        }

        public override void Down(IMongoDatabase db)
        {
            var collection = db.GetCollection<Car>("Car");
            collection.DeleteOne(Builders<Car>.Filter.Eq(c => c.Type, "AddedInMigration"));
        }
    }
}