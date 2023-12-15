using MongoDB.Driver;

namespace PruebaTecnica.Repositorio
{
    public class RepositorioMongo
    {
        public MongoClient cliente;
        public IMongoDatabase baseDatos;

        public RepositorioMongo(AccesoDatos cadenaconexion)
        {
            cliente = new MongoClient(cadenaconexion.CadenaConexionMongo);
            baseDatos = cliente.GetDatabase("PruebaTecnica");
        }
    }
}
