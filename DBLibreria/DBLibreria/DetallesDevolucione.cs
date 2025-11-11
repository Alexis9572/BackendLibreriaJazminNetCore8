using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria.DBLibreria;

[Table("Detalles_devoluciones")]
public partial class DetallesDevolucione
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("devolucion_id")]
    public int DevolucionId { get; set; }

    [Column("producto_id")]
    public int ProductoId { get; set; }

    [Column("cantidad")]
    public int Cantidad { get; set; }

    [InverseProperty("DetalleDevolucion")]
    public virtual ICollection<DetallesReembolso> DetallesReembolsos { get; set; } = new List<DetallesReembolso>();

    [ForeignKey("DevolucionId")]
    [InverseProperty("DetallesDevoluciones")]
    public virtual Devolucione Devolucion { get; set; } = null!;

    [ForeignKey("ProductoId")]
    [InverseProperty("DetallesDevoluciones")]
    public virtual Producto Producto { get; set; } = null!;
}
