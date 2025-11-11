using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria.DBLibreria;

[Table("Detalles_promociones")]
public partial class DetallesPromocione
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("promocion_id")]
    public int PromocionId { get; set; }

    [Column("producto_id")]
    public int ProductoId { get; set; }

    [Column("porcentaje")]
    public int Porcentaje { get; set; }

    [Column("monto_minimo", TypeName = "decimal(10, 2)")]
    public decimal MontoMinimo { get; set; }

    [ForeignKey("ProductoId")]
    [InverseProperty("DetallesPromociones")]
    public virtual Producto Producto { get; set; } = null!;

    [ForeignKey("PromocionId")]
    [InverseProperty("DetallesPromociones")]
    public virtual Promocione Promocion { get; set; } = null!;
}
