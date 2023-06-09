using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWPF.Core
{
    public class Ticket
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string MovieName { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Poster { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string HallName { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string PlaceNumber { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Date { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Time { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public DateTime DateTimeCreate { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public User User { get; set; }
    }
}
