using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria.DBLibreria;

public partial class Devolucione
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("fecha", TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [Column("persona_id")]
    public int PersonaId { get; set; }

    [Column("pedido_id")]
    public int PedidoId { get; set; }

    [Column("productos")]
    [Unicode(false)]
    public string Productos { get; set; } = null!;

    [Column("motivo")]
    [StringLength(255)]
    [Unicode(false)]
    public string Motivo { get; set; } = null!;

    [Column("estado")]
    [StringLength(255)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    [InverseProperty("Devolucion")]
    public virtual ICollection<DetallesDevolucione> DetallesDevoluciones { get; set; } = new List<DetallesDevolucione>();

    [ForeignKey("PedidoId")]
    [InverseProperty("Devoluciones")]
    public virtual Pedido Pedido { get; set; } = null!;

    [ForeignKey("PersonaId")]
    [InverseProperty("Devoluciones")]
    public virtual Persona Persona { get; set; } = null!;
}
