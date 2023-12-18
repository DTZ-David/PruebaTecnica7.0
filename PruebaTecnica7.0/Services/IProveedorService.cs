using PruebaTecnica.Dtos;
using PruebaTecnica.Models;

namespace PruebaTecnica.Services
{
    public interface IProveedorService
    {
        IEnumerable<ProveedorDTO> GetAll();
        Proveedor Get(int Nit);
        Proveedor Create(Proveedor proveedores);
        void Update(Proveedor proveedores);
        void Remove (int nit);
    }
}
