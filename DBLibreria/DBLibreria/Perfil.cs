using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria;

[Keyless]
public partial class Perfil
{
    [Column("nombreRol")]
    [StringLength(50)]
    [Unicode(false)]
    public string NombreRol { get; set; } = null!;

    [Column("rol_id")]
    public int RolId { get; set; }

    [Column("id")]
    public int Id { get; set; }

    [Column("persona_id")]
    public int PersonaId { get; set; }

    [Column("usuario")]
    [StringLength(50)]
    [Unicode(false)]
    public string Usuario1 { get; set; } = null!;

    [Column("nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("apellidos")]
    [StringLength(100)]
    [Unicode(false)]
    public string Apellidos { get; set; } = null!;

    [Column("telefono")]
    [StringLength(20)]
    [Unicode(false)]
    public string Telefono { get; set; } = null!;

    [Column("direccion", TypeName = "text")]
    public string Direccion { get; set; } = null!;

    [Column("correo")]
    [StringLength(100)]
    [Unicode(false)]
    public string Correo { get; set; } = null!;
}
