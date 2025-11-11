using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestResponse
{
    public class ProductoRequest
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;

        [Column("descripcion")]
        [StringLength(255)]
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;

        [Column("precio", TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }

        [Column("stock")]
        public int Stock { get; set; }

        [Column("categoria")]
        [StringLength(50)]
        [Unicode(false)]
        public string Categoria { get; set; } = null!;

        //[InverseProperty("Producto")]
        //public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();

        //[InverseProperty("Producto")]
        //public virtual ICollection<DetallesDevolucione> DetallesDevoluciones { get; set; } = new List<DetallesDevolucione>();

        //[InverseProperty("Producto")]
        //public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();

        //[InverseProperty("Producto")]
        //public virtual ICollection<DetallesPromocione> DetallesPromociones { get; set; } = new List<DetallesPromocione>();

        //[InverseProperty("Producto")]
        //public virtual ICollection<Imagene> Imagenes { get; set; } = new List<Imagene>();

        //[InverseProperty("Producto")]
        //public virtual ICollection<ProveedorProducto> ProveedorProductos { get; set; } = new List<ProveedorProducto>();
    }
}
