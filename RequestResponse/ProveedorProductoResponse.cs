using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class ProveedorProductoResponse
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("proveedor_id")]
        public int ProveedorId { get; set; }

        [Column("producto_id")]
        public int ProductoId { get; set; }

        //[ForeignKey("ProductoId")]
        //[InverseProperty("ProveedorProductos")]
        //public virtual Producto Producto { get; set; } = null!;

        //[ForeignKey("ProveedorId")]
        //[InverseProperty("ProveedorProductos")]
        //public virtual Proveedore Proveedor { get; set; } = null!;
    }
}
