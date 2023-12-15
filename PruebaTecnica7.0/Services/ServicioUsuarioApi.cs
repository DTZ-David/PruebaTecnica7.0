using MongoDB.Driver;
using PruebaTecnica.Dtos;
using PruebaTecnica.Models;
using PruebaTecnica.Repositorio;

namespace PruebaTecnica.Services
{
    public class ServicioUsuarioApi : IServicioUsuarioApi
    {
        internal RepositorioMongo repositorio;
        private IMongoCollection<UsuarioAPI> _usuarioApi;
    
        public ServicioUsuarioApi(AccesoDatos accesoDatos)
        {
            repositorio = new RepositorioMongo(accesoDatos);
            _usuarioApi = repositorio.baseDatos.GetCollection<UsuarioAPI>("UsuarioAPI");
        }
        public UsuarioAPI GetUsuario(LoginApiDTO login)
        {
            try
            {
                var filter = Builders<UsuarioAPI>.Filter.Eq(u => u.Usuario, login.UsuarioApi);

                return _usuarioApi.Find(filter).FirstOrDefault();

            }catch (Exception ex)
            {
                throw new Exception("Se produjo un error al obtener los datos del usuario" + ex.Message);
            }
        }

        
    }
}
