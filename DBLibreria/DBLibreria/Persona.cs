using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria.DBLibreria;

[Table("Persona")]
public partial class Persona
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

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

    [Column("idtipodocumento")]
    public int Idtipodocumento { get; set; }

    [InverseProperty("Persona")]
    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();

    [InverseProperty("Persona")]
    public virtual ICollection<Devolucione> Devoluciones { get; set; } = new List<Devolucione>();

    [ForeignKey("Idtipodocumento")]
    [InverseProperty("Personas")]
    public virtual TipoDocumento IdtipodocumentoNavigation { get; set; } = null!;

    [InverseProperty("Persona")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    [InverseProperty("Persona")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
