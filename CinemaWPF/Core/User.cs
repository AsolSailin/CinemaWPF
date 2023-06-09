using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWPF.Core
{
    public class User
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Role { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Login { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Password { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string PasswordRepeat { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Surname { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Name { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Patronymic { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string EMail { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string PhoneNumber { get; set; }
    }
}
