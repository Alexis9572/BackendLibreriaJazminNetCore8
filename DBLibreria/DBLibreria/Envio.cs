using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria.DBLibreria;

public partial class Envio
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("fecha", TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [Column("pedido_id")]
    public int PedidoId { get; set; }

    [Column("numero_seguimiento")]
    [StringLength(255)]
    [Unicode(false)]
    public string NumeroSeguimiento { get; set; } = null!;

    [Column("direccion_destino")]
    [StringLength(255)]
    [Unicode(false)]
    public string DireccionDestino { get; set; } = null!;

    [Column("estado")]
    [StringLength(255)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    [ForeignKey("PedidoId")]
    [InverseProperty("Envios")]
    public virtual Pedido Pedido { get; set; } = null!;
}
