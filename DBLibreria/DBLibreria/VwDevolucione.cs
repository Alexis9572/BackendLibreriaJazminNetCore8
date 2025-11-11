using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria;

[Keyless]
public partial class VwDevolucione
{
    [Column("cantidad")]
    public int Cantidad { get; set; }

    [Column("fecha", TypeName = "datetime")]
    public DateTime Fecha { get; set; }

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

    [Unicode(false)]
    public string Expr1 { get; set; } = null!;
}
