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
    public class DevolucioneResponse
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("fecha", TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [Column("pedido_id")]
        public int PedidoId { get; set; }

        [Column("motivo")]
        [StringLength(255)]
        [Unicode(false)]
        public string Motivo { get; set; } = null!;

        [Column("estado")]
        [StringLength(255)]
        [Unicode(false)]
        public string Estado { get; set; } = null!;

        //[ForeignKey("ClienteId")]
        //[InverseProperty("Devoluciones")]
        //public virtual Cliente Cliente { get; set; } = null!;

        //[InverseProperty("Devolucion")]
        //public virtual ICollection<DetallesDevolucione> DetallesDevoluciones { get; set; } = new List<DetallesDevolucione>();

        //[ForeignKey("PedidoId")]
        //[InverseProperty("Devoluciones")]
        //public virtual Pedido Pedido { get; set; } = null!;
    }
}
