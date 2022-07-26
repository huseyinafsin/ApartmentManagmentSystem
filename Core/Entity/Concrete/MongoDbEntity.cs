﻿using System;
using Core.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entity.Concrete
{
    public abstract class MongoDbEntity : IEntity<string>
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        //[BsonId]
        //[BsonElement(Order = 0)]
        //public string Id { get; } = ObjectId.GenerateNewId().ToString();
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonElement(Order = 101)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool Status { get; set; }
    }
}