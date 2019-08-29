using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Models
{
    public class Log
    {
        public Log(string owner, string phone, string email, string action)
        {
            Owner = owner;
            Phone = phone;
            Email = email;
            Action = action;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Owner")]
        public string Owner { get; set; }


        [BsonElement("Action")]
        public string Action { get; set; }

        [BsonElement("Phone")]
        public string Phone { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }


    }
}
