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
    public class ImageneRequest
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("producto_id")]
        public int ProductoId { get; set; }

        [Column("nombre")]
        [StringLength(255)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;

        [Column("tipo")]
        [StringLength(255)]
        [Unicode(false)]
        public string Tipo { get; set; } = null!;

        [Column("contenido")]
        public byte[] Contenido { get; set; } = null!;

        //[ForeignKey("ProductoId")]
        //[InverseProperty("Imagenes")]
        //public virtual Producto Producto { get; set; } = null!;
    }
}
