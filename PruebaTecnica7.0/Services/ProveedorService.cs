using PruebaTecnica.Models;
using MongoDB.Driver;
using PruebaTecnica.Repositorio;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Dtos;

namespace PruebaTecnica.Services
{
    public class ProveedorService : IProveedorService
    {
        internal RepositorioMongo repositorio;
        private IMongoCollection<Proveedor> _proveedores;
      
        public ProveedorService(AccesoDatos accesoDatos)
        {
            repositorio = new RepositorioMongo(accesoDatos);
            _proveedores = repositorio.baseDatos.GetCollection<Proveedor>("Proveedores");
            
        }

        public Proveedor Create(Proveedor proveedores)
        {
            _proveedores.InsertOne(proveedores);
            return proveedores;
        }

        public IEnumerable<ProveedorDTO> GetAll()
        {
            var coleccion = _proveedores.Find(proveedores => true).ToList();
            var resultado = coleccion.Select(proveedor => proveedor.ConvertirDTO());

            return resultado;
        }


        public Proveedor Get(int Nit)
        {
            var proveedor = _proveedores.Find(proveedores => proveedores.NIT == Nit).FirstOrDefault();
            return proveedor;
        }


        public void Remove(int Nit)
        {
            _proveedores.DeleteOne(proveedores => proveedores.NIT == Nit);
        }

        public void Update(Proveedor proveedor)
        {
            var filtro = Builders<Proveedor>.Filter.Eq(s => s.Id, proveedor.Id);
            _proveedores.ReplaceOneAsync(filtro, proveedor);
        }
    }
}
