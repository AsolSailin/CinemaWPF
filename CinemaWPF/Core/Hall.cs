using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWPF.Core
{
    public class Hall
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Name { get; set; }

        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public Dictionary<string, string> Places = new Dictionary<string, string>()
        {
            {"1", "false"}, {"2", "false"}, {"3", "false"}, {"4", "false"}, {"5", "false"},
            {"6", "false"}, {"7", "false"}, {"8", "false"}, {"9", "false"}, {"10", "false"},
            {"11", "false"}, {"12", "false"}, {"13", "false"}, {"14", "false"}, {"15", "false"},
            {"16", "false"}, {"17", "false"}, {"18", "false"}, {"19", "false"}, {"20", "false"},
            {"21", "false"}, {"22", "false"}, {"23", "false"}, {"24", "false"}, {"25", "false"},
            {"26", "false"}, {"27", "false"}, {"28", "false"}, {"29", "false"}, {"30", "false"},
            {"31", "false"}, {"32", "false"}, {"33", "false"}, {"34", "false"}, {"35", "false"},
            {"36", "false"}, {"37", "false"}, {"38", "false"}, {"39", "false"}, {"40", "false"},
            {"41", "false"}, {"42", "false"}, {"43", "false"}, {"44", "false"}, {"45", "false"},
            {"46", "false"}, {"47", "false"}, {"48", "false"}, {"49", "false"}, {"50", "false"},
        };
    }
}
