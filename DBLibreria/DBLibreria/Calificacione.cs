using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria.DBLibreria;

public partial class Calificacione
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("persona_id")]
    public int PersonaId { get; set; }

    [Column("producto_id")]
    public int ProductoId { get; set; }

    [Column("calificacion")]
    public int Calificacion { get; set; }

    [Column("comentario")]
    [StringLength(255)]
    [Unicode(false)]
    public string Comentario { get; set; } = null!;

    [ForeignKey("PersonaId")]
    [InverseProperty("Calificaciones")]
    public virtual Persona Persona { get; set; } = null!;

    [ForeignKey("ProductoId")]
    [InverseProperty("Calificaciones")]
    public virtual Producto Producto { get; set; } = null!;
}
