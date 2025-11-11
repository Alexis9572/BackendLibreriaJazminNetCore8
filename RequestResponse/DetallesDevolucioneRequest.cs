using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class DetallesDevolucioneRequest
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("devolucion_id")]
        public int DevolucionId { get; set; }

        [Column("producto_id")]
        public int ProductoId { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        //[InverseProperty("DetalleDevolucion")]
        //public virtual ICollection<DetallesReembolso> DetallesReembolsos { get; set; } = new List<DetallesReembolso>();

        //[ForeignKey("DevolucionId")]
        //[InverseProperty("DetallesDevoluciones")]
        //public virtual Devolucione Devolucion { get; set; } = null!;

        //[ForeignKey("ProductoId")]
        //[InverseProperty("DetallesDevoluciones")]
        //public virtual Producto Producto { get; set; } = null!;
    }
}
