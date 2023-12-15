using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PruebaTecnica.Models
{
    public class UsuarioAPI
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Usuario")]
        public string Usuario { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        public String Token { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("FechaAlta")]
        public DateTime? FechaAlta { get; set; }

        [BsonElement("FechaBaja")]
        public DateTime? FechaBaja { get; set; }
    }
}
