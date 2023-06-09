using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWPF.Core
{
    public class Movie
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Poster { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Name { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Genre { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Regisseur { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Producer { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Script { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Country { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Duration { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Description { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Price2D { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Price3D { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string PriceVIP { get; set; }
    }
}
