using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class ProveedoreRequest
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;

        [Column("direccion")]
        [StringLength(255)]
        [Unicode(false)]
        public string Direccion { get; set; } = null!;

        [Column("telefono")]
        [StringLength(15)]
        [Unicode(false)]
        public string Telefono { get; set; } = null!;

        [Column("correo_electronico")]
        [StringLength(255)]
        [Unicode(false)]
        public string CorreoElectronico { get; set; } = null!;

        //[InverseProperty("Proveedor")]
        //public virtual ICollection<ProveedorProducto> ProveedorProductos { get; set; } = new List<ProveedorProducto>();
    }
}
