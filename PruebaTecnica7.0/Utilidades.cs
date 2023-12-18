using PruebaTecnica.Dtos;
using PruebaTecnica.Models;
using System.Security.Cryptography;
using System.Text;

namespace PruebaTecnica
{
    public static class Utilidades
    {
        public static ProveedorDTO ConvertirDTO(this Proveedor proveedorDTO)
        {
            if(proveedorDTO != null)
            {
                return new ProveedorDTO
                {
                    Id = proveedorDTO.Id,
                    NIT = proveedorDTO.NIT,
                    RazonSocial = proveedorDTO.RazonSocial,
                    Direccion = proveedorDTO.Direccion,
                    Ciudad = proveedorDTO.Ciudad,
                    Correo = proveedorDTO.Correo,
                    NombreContacto = proveedorDTO.NombreContacto,
                    CorreoContacto = proveedorDTO.CorreoContacto
                };
            }
            return null;
        }

        public static UsuarioApiDTO ConvertirDTO(this UsuarioAPI usuarioAPI)
        {
            if(usuarioAPI != null)
            {
                return new UsuarioApiDTO
                {
                    Token = usuarioAPI.Token,
                    Usuario = usuarioAPI.Usuario,
                };
            }
            return null;
        }

        public static string Encriptar(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hasedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hasedBytes).Replace("-","").ToLower();
            }
        }

        public static bool Desencriptar(string plainTextPassword, string hashedPassword)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainTextPassword));
                string hashedInput = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                if(hashedInput == hashedPassword)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
