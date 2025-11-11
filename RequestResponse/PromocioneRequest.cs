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
    public class PromocioneRequest
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

        [Column("fecha_inicio", TypeName = "datetime")]
        public DateTime FechaInicio { get; set; }

        [Column("fecha_fin", TypeName = "datetime")]
        public DateTime FechaFin { get; set; }

        [Column("tipo")]
        [StringLength(50)]
        [Unicode(false)]
        public string Tipo { get; set; } = null!;

        [Column("valor", TypeName = "decimal(10, 2)")]
        public decimal Valor { get; set; }

        //[InverseProperty("Promocion")]
        //public virtual ICollection<DetallesPromocione> DetallesPromociones { get; set; } = new List<DetallesPromocione>();
    }
}
