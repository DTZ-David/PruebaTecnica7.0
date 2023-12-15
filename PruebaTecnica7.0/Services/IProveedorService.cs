using PruebaTecnica.Models;

namespace PruebaTecnica.Services
{
    public interface IProveedorService
    {
        IEnumerable<Proveedor> GetAll();
        Proveedor Get(string id);
        Proveedor Create(Proveedor proveedores);
        void Update(Proveedor proveedores);
        void Remove (int id);
    }
}
