using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria.DBLibreria;

[Table("TipoDocumento")]
public partial class TipoDocumento
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

    [InverseProperty("IdtipodocumentoNavigation")]
    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
