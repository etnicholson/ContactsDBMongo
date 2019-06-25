using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Models
{
    public class Email
    {
        public Email(string personID, string userEmail, DateTime date)
        {
            PersonID = personID;
            UserEmail = userEmail;
            Date = date;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("PersonID")]
        public string PersonID { get; set; }

        [BsonElement("Email")]
        public string UserEmail { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }
    }
}
