using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContactsDBAPI.Models
{
    public class Person
    {
        public Person(string name, string city, string notes)
        {
            Name = name;
            City = city;
            Notes = notes;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("City")]
        public string City { get; set; }

        [BsonElement("Notes")]
        public string Notes { get; set; }
    }
}
