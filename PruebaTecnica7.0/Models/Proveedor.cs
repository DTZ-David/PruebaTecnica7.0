using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PruebaTecnica.Models
{
    [BsonIgnoreExtraElements]
    public class Proveedor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("NIT")]
        public int NIT { get; set; }

        [BsonElement("RazonSocial")]
        public string RazonSocial { get; set; }

        [BsonElement("Direccion")]
        public string Direccion { get; set; }

        [BsonElement("Ciudad")]
        public string Ciudad { get; set; }

        [BsonElement("Departamento")]
        public string Departamento { get; set; }

        [BsonElement("Correo")]
        public string Correo { get; set; }

        [BsonElement("Activo")]
        public bool Activo { get; set; }

        [BsonElement("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [BsonElement("NombreContacto")]
        public string NombreContacto { get; set; }

        [BsonElement("CorreoContacto")]
        public string CorreoContacto { get; set; }

    }
}
