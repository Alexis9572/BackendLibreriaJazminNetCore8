using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria.DBLibreria;

public partial class Pedido
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("fecha", TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [Column("persona_id")]
    public int PersonaId { get; set; }

    [Column("productos")]
    [Unicode(false)]
    public string Productos { get; set; } = null!;

    [Column("monto_total", TypeName = "decimal(10, 2)")]
    public decimal MontoTotal { get; set; }

    [Column("direccion_envio")]
    [StringLength(255)]
    [Unicode(false)]
    public string DireccionEnvio { get; set; } = null!;

    [InverseProperty("Pedido")]
    public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();

    [InverseProperty("Pedido")]
    public virtual ICollection<Devolucione> Devoluciones { get; set; } = new List<Devolucione>();

    [InverseProperty("Pedido")]
    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

    [ForeignKey("PersonaId")]
    [InverseProperty("Pedidos")]
    public virtual Persona Persona { get; set; } = null!;
}
