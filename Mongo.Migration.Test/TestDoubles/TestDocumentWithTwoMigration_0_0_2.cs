﻿using System;
using Mongo.Migration.Migrations;
using Mongo.Migration.Migrations.Attributes;
using MongoDB.Bson;

namespace Mongo.Migration.Test.TestDoubles
{
    [MigrationMarker]
    internal class TestDocumentWithTwoMigration_0_0_2 : Migration<TestDocumentWithTwoMigration>
    {
        public TestDocumentWithTwoMigration_0_0_2() : base("0.0.2")
        {
        }

        public override void Up(BsonDocument document)
        {
            var doors = document["Doors"].ToInt32();
            document.Add("Door", doors);
            document.Remove("Doors");
        }

        public override void Down(BsonDocument document)
        {
            var doors = document["Door"].ToInt32();
            document.Add("Doors", doors);
            document.Remove("Door");
        }
    }
}