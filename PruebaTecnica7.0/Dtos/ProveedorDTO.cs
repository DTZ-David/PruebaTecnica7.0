using MongoDB.Bson.Serialization.Attributes;

namespace PruebaTecnica.Dtos
{
    public class ProveedorDTO
    {
        [BsonElement("id")]
        public string Id { get; set; }

        [BsonElement("NIT")]
        public int NIT { get; set; }

        [BsonElement("RazonSocial")]
        public string RazonSocial { get; set; }

        [BsonElement("Direccion")]
        public string Direccion { get; set; }

        [BsonElement("Ciudad")]
        public string Ciudad { get; set; }
        [BsonElement("Correo")]
        public string Correo { get; set; }

        [BsonElement("NombreContacto")]
        public string NombreContacto { get; set; }

        [BsonElement("CorreoContacto")]
        public string CorreoContacto { get; set; }

    }
}
