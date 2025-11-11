using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class DetallesPedidoResponse
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("pedido_id")]
        public int PedidoId { get; set; }

        [Column("producto_id")]
        public int ProductoId { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("precio_unitario", TypeName = "decimal(10, 2)")]
        public decimal PrecioUnitario { get; set; }

        //[ForeignKey("PedidoId")]
        //[InverseProperty("DetallesPedidos")]
        //public virtual Pedido Pedido { get; set; } = null!;

        //[ForeignKey("ProductoId")]
        //[InverseProperty("DetallesPedidos")]
        //public virtual Producto Producto { get; set; } = null!;
    }
}
