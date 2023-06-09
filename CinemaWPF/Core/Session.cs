using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWPF.Core
{
    public class Session
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public DateTime Time { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public Movie Movie { get; set; } = new Movie();

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public Hall Hall { get; set; } = new Hall();
    }
}
