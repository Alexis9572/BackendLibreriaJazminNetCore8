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
        public class PedidoRequest
        {
            [Key]
            [Column("id")]
            public int Id { get; set; }

            [Column("fecha", TypeName = "datetime")]
            public DateTime Fecha { get; set; }

            [Column("cliente_id")]
            public int ClienteId { get; set; }

            [Column("direccion_envio")]
            [StringLength(255)]
            [Unicode(false)]
            public string DireccionEnvio { get; set; } = null!;

            //[ForeignKey("ClienteId")]
            //[InverseProperty("Pedidos")]
            //public virtual Cliente Cliente { get; set; } = null!;

            //[InverseProperty("Pedido")]
            //public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();

            //[InverseProperty("Pedido")]
            //public virtual ICollection<Devolucione> Devoluciones { get; set; } = new List<Devolucione>();

            //[InverseProperty("Pedido")]
            //public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();
        }
}
