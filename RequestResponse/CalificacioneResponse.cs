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
    public class CalificacioneResponse
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [Column("producto_id")]
        public int ProductoId { get; set; }

        [Column("calificacion")]
        public int Calificacion { get; set; }

        [Column("comentario")]
        [StringLength(255)]
        [Unicode(false)]
        public string Comentario { get; set; } = null!;

        //[ForeignKey("ClienteId")]
        //[InverseProperty("Calificaciones")]
        //public virtual Cliente Cliente { get; set; } = null!;

        //[ForeignKey("ProductoId")]
        //[InverseProperty("Calificaciones")]
        //public virtual Producto Producto { get; set; } = null!;
    }
}
