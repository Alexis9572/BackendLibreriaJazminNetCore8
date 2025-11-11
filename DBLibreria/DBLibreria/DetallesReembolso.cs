using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria.DBLibreria;

[Table("Detalles_Reembolsos")]
public partial class DetallesReembolso
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("detalle_devolucion_id")]
    public int DetalleDevolucionId { get; set; }

    [Column("cambio")]
    [StringLength(255)]
    public string Cambio { get; set; } = null!;

    [Column("monto", TypeName = "decimal(10, 2)")]
    public decimal Monto { get; set; }

    [ForeignKey("DetalleDevolucionId")]
    [InverseProperty("DetallesReembolsos")]
    public virtual DetallesDevolucione DetalleDevolucion { get; set; } = null!;
}
