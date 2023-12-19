using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PruebaTecnica.Dtos;
using PruebaTecnica.Models;
using PruebaTecnica.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginApiController : Controller
    {
        private readonly IServicioUsuarioApi servicio;
        private readonly IConfiguration configuration;

        public LoginApiController(IServicioUsuarioApi s, IConfiguration configuration)
        {
            this.servicio = s;
            this.configuration = configuration;
        }


        /// <summary>
        /// Valida el usuario y genera el token para la autenticación
        /// </summary>
        /// <respone code="200">Valida el usuario y genera el token para la autenticación</respone>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UsuarioApiDTO> Login(LoginApiDTO loginApiDTO)
        {
            try
            {
                UsuarioAPI Usuario = null;
                Usuario = AutenticarUsuario(loginApiDTO);
                if (Usuario == null)
                    throw new Exception("Credenciales no válidas");
                else
                    Usuario = GenerarTokenJWT(Usuario);

                return Usuario.ConvertirDTO();
            }
            catch (Exception ex)
            {
                return BadRequest("Error en la autenticación: " + ex.Message);
            }
            
        }
        private UsuarioAPI AutenticarUsuario(LoginApiDTO usuarioLogin)
        {
            UsuarioAPI usuarioAPI = servicio.GetUsuario(usuarioLogin);

            // Lógica para validar la contraseña
            bool contraseniaValida = Utilidades.Desencriptar(usuarioLogin.PasswordApi, usuarioAPI.Password);

            if (!contraseniaValida)
            {
                throw new Exception("Los datos del login no son correctos");
            }

            return usuarioAPI;
        }
        private UsuarioAPI GenerarTokenJWT(UsuarioAPI usuarioInfo)
        {
            // Cabecera 
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            var _signingCredentials = new SigningCredentials(
            _symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var _Header = new JwtHeader(_signingCredentials);

            // Claims
            var _Claims = new[] {
                new Claim("usuario", usuarioInfo.Usuario),
                new Claim("email", usuarioInfo.Email),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email),
            };
            //Payload
            var _Payload = new JwtPayload(
                  issuer: configuration["JWT:Issuer"],
                  audience: configuration["JWT:Audience"],
                  claims: _Claims,
                  notBefore: DateTime.UtcNow,
                  expires: DateTime.UtcNow.AddMinutes(30));

            // Token
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            usuarioInfo.Token = new JwtSecurityTokenHandler().WriteToken(_Token);

            return usuarioInfo;

        }
        
    }
}
