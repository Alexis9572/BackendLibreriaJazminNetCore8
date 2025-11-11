using DBLibreria;
using DBLibreria.DBLibreria;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductoVWRepository : CRUDRepository<VwProducto>, IProductoVWRepository
    {
        public VwProducto obtenerListaProducto(string nombreProducto)
        {
            VwProducto? orden = db.VwProductos.Where(x => x.Nombre == nombreProducto).FirstOrDefault();
            return orden;
 
        }
    }
}
