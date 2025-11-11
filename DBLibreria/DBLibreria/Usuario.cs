using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria.DBLibreria;

[Table("Usuario")]
public partial class Usuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("usuario")]
    [StringLength(50)]
    [Unicode(false)]
    public string Usuario1 { get; set; } = null!;

    [Column("contrasenia")]
    [StringLength(255)]
    [Unicode(false)]
    public string Contrasenia { get; set; } = null!;

    [Column("estado")]
    [StringLength(20)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    [Column("persona_id")]
    public int PersonaId { get; set; }

    [Column("rol_id")]
    public int RolId { get; set; }

    [ForeignKey("PersonaId")]
    [InverseProperty("Usuarios")]
    public virtual Persona Persona { get; set; } = null!;

    [ForeignKey("RolId")]
    [InverseProperty("Usuarios")]
    public virtual Rol Rol { get; set; } = null!;
}
