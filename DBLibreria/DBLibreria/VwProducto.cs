using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria;

[Keyless]
public partial class VwProducto
{
    [Column("nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("descripcion")]
    [StringLength(255)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [Column("precio", TypeName = "decimal(10, 2)")]
    public decimal Precio { get; set; }

    [Column("categoria")]
    [StringLength(50)]
    [Unicode(false)]
    public string Categoria { get; set; } = null!;

    [Column("tipo")]
    [StringLength(255)]
    [Unicode(false)]
    public string Tipo { get; set; } = null!;

    [Column("id")]
    public int Id { get; set; }

    [Column("stock")]
    public int Stock { get; set; }
}
