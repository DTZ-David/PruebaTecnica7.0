using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Dtos;
using PruebaTecnica.Models;
using PruebaTecnica.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnica.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService proveedorService;
        public ProveedorController(IProveedorService proveedorService)
        {
            this.proveedorService = proveedorService;
        }
        /// <summary>
        /// Este endpoint obtiene y retorna todos los proveedores de la base de datos.
        /// </summary>
        /// <respone code="200">Retorna una lista de todos los proveedores en el sistema</respone>
        // GET: api/<ProveedoresController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var items = proveedorService.GetAll();
            return Ok(items);
        }

        /// <summary>
        /// Este endpoint obtiene y retorna un proveedor especifico de la base de datos.
        /// </summary>
        /// <respone code="200">Retorna un proveedor especifico buscando por el id</respone>
        // GET api/<ProveedoresController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var proveedor = (proveedorService.Get(id)).ConvertirDTO();
            if(proveedor == null)
            {
                return NotFound("Proveedor no encontrado");
            }
            return Ok(proveedor);
        }

        /// <summary>
        /// Crea un proveedor nuevo en el sistema.
        /// </summary>
        /// <respone code="200">Crea un proveedor nuevo en el sistema</respone>
        // POST api/<ProveedoresController>
        [HttpPost]
        public IActionResult Post([FromBody] ProveedorDTO proveedor)
        {
            if (proveedor == null)
                return BadRequest();

            Proveedor p = new Proveedor
            {
                NIT = proveedor.NIT,
                RazonSocial = proveedor.RazonSocial,
                Direccion = proveedor.Direccion,
                Ciudad = proveedor.Ciudad,
                Correo = proveedor.Correo,
                FechaCreacion = DateTime.Now,
                NombreContacto = proveedor.NombreContacto,
                CorreoContacto = proveedor.CorreoContacto
            };
            proveedorService.Create(p);
            return CreatedAtAction(nameof(Get) , new {Nit = proveedor.NIT}, proveedor);
        }

        /// <summary>
        /// Actualiza la información de un proveedor en el sistema.
        /// </summary>
        /// <respone code="200">Actualiza la información(algunos campos) de un proveedor en especifico</respone>
        // PUT api/<ProveedoresController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Proveedor proveedor)
        {
            var existingProveedor = proveedorService.Get(id);

            if (existingProveedor == null)
            {
                return NotFound($"El proveedor con el id = {id} no fue encontrado");
            }

            proveedorService.Update(proveedor);

            return NoContent();
        }
        /// <summary>
        /// Elimina un proveedor del sistema.
        /// </summary>
        /// <respone code="200">Elimina un proveedor del sistema</respone>
        // DELETE api/<ProveedoresController>/5
        [HttpDelete("{NIT}")]
        public IActionResult Delete(string Nit)
        {
            var proveedor = proveedorService.Get(Nit);

            if (proveedor == null)
            {
                return NotFound($"El proveedor con el NIT = {Nit} no fue encontrado");
            }

            proveedorService.Remove(proveedor.NIT);

            return Ok($"El proveedor con el NIT = {Nit} eliminado");
        }
    }
}
