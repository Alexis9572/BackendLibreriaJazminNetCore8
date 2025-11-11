using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria.DBLibreria;

[Table("ProveedorProducto")]
public partial class ProveedorProducto
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("proveedores_id")]
    public int ProveedoresId { get; set; }

    [Column("productos_id")]
    public int ProductosId { get; set; }

    [ForeignKey("ProductosId")]
    [InverseProperty("ProveedorProductos")]
    public virtual Producto Productos { get; set; } = null!;

    [ForeignKey("ProveedoresId")]
    [InverseProperty("ProveedorProductos")]
    public virtual Proveedore Proveedores { get; set; } = null!;
}
