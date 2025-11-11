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
    public class RolRequest
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        [StringLength(50)]
        [Unicode(false)]
        public string NombreRol { get; set; } = null!;

        //[InverseProperty("Rol")]
        //public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
