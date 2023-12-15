using PruebaTecnica.Dtos;
using PruebaTecnica.Models;

namespace PruebaTecnica.Services
{
    public interface IServicioUsuarioApi
    {
        UsuarioAPI GetUsuario(LoginApiDTO login);
    }
}
