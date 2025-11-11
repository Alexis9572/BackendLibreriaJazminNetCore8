using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria.DBLibreria;

public partial class Proveedore
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("direccion")]
    [StringLength(255)]
    [Unicode(false)]
    public string Direccion { get; set; } = null!;

    [Column("telefono")]
    [StringLength(15)]
    [Unicode(false)]
    public string Telefono { get; set; } = null!;

    [Column("correo_electronico")]
    [StringLength(255)]
    [Unicode(false)]
    public string CorreoElectronico { get; set; } = null!;

    [Column("productos")]
    [Unicode(false)]
    public string Productos { get; set; } = null!;

    [InverseProperty("Proveedores")]
    public virtual ICollection<ProveedorProducto> ProveedorProductos { get; set; } = new List<ProveedorProducto>();
}
