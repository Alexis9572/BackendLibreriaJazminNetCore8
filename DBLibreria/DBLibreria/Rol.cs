using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria.DBLibreria;

[Table("Rol")]
public partial class Rol
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombreRol")]
    [StringLength(50)]
    [Unicode(false)]
    public string NombreRol { get; set; } = null!;

    [InverseProperty("Rol")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
