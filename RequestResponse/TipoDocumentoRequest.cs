using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RequestResponse
{
    public class TipoDocumentoRequest
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;

        [Column("documento")]
        [StringLength(20)]
        [Unicode(false)]
        public string Documento { get; set; } = null!;

        //[InverseProperty("IdtipodocumentoNavigation")]
        //public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
    }
}
