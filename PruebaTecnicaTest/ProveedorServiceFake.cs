using PruebaTecnica.Models;
using PruebaTecnica.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaTest
{
    internal class ProveedorServiceFake : IProveedorService
    {
        private readonly List<Proveedor> _proveedor;
        public ProveedorServiceFake()
        {
            _proveedor = new List<Proveedor>()
            {
               new Proveedor {
        Id = "1",
        NIT = 1234567890,
        RazonSocial = "Proveedor 1",
        Direccion = "Calle 123",
        Ciudad = "Ciudad 1",
        Departamento = "Departamento 1",
        Correo = "proveedor1@example.com",
        Activo = true,
        FechaCreacion = DateTime.Now,
        NombreContacto = "Contacto 1",
        CorreoContacto = "contacto1@example.com"
    },
    new Proveedor {
        Id = "2",
        NIT = 987643210,
        RazonSocial = "Proveedor 2",
        Direccion = "Avenida 456",
        Ciudad = "Ciudad 2",
        Departamento = "Departamento 2",
        Correo = "proveedor2@example.com",
        Activo = true,
        FechaCreacion = DateTime.Now,
        NombreContacto = "Contacto 2",
        CorreoContacto = "contacto2@example.com"
    }
            };
        }
        public Proveedor Create(Proveedor newItem)
        {

            _proveedor.Add(newItem);
            return newItem;
        }

        public IEnumerable<Proveedor> GetAll()
        {
            return _proveedor;
        }

        public Proveedor Get(string id)
        {
            return _proveedor.Where(a => a.Id == id)
           .FirstOrDefault();
        }

        public void Remove(int id)
        {
            var existing = _proveedor.First(a => a.NIT == id);
            _proveedor.Remove(existing);
        }

        public void Update(Proveedor proveedores)
        {
            throw new NotImplementedException();
        }
    }
}
