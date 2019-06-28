using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Models
{
    public class Phone
    {
        public Phone(string personID, string number, DateTime date)
        {
            PersonID = personID;
            Number = number;
            Date = date;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("PersonID")]
        public string PersonID { get; set; }

        [BsonElement("Number")]
        public string Number { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

    }
}
