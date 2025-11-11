using System;
using System.Collections.Generic;
using DBLibreria.DBLibreria;
using Microsoft.EntityFrameworkCore;

namespace DBLibreria;

public partial class _dbLibreriaContext : DbContext
{
    public _dbLibreriaContext()
    {
    }

    public _dbLibreriaContext(DbContextOptions<_dbLibreriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calificacione> Calificaciones { get; set; }

    public virtual DbSet<DetallesDevolucione> DetallesDevoluciones { get; set; }

    public virtual DbSet<DetallesPedido> DetallesPedidos { get; set; }

    public virtual DbSet<DetallesPromocione> DetallesPromociones { get; set; }

    public virtual DbSet<DetallesReembolso> DetallesReembolsos { get; set; }

    public virtual DbSet<Devolucione> Devoluciones { get; set; }

    public virtual DbSet<Envio> Envios { get; set; }

    public virtual DbSet<Imagene> Imagenes { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Perfil> Perfils { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Promocione> Promociones { get; set; }

    public virtual DbSet<ProveedorProducto> ProveedorProductos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VwDevolucione> VwDevoluciones { get; set; }

    public virtual DbSet<VwProducto> VwProductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SQL9001.site4now.net;Initial Catalog=db_abf142_libreriajazmin;User Id=db_abf142_libreriajazmin_admin;Password=Alexis9572");
    //Server=ssql9001.site4now.net;Database=db_abf142_libreriajazmin;User Id=db_abf142_libreriajazmin_admin;Password=Alexis9572;MultipleActiveResultSets=true
    //Data Source=DESKTOP-IFHIDDS\\SQLEXPRESS;Initial Catalog=LibreriaJazmin;Integrated Security=True;Trusted_Connection=true;Trust Server Certificate=true

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calificacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Califica__3213E83F9150BD68");

            entity.HasOne(d => d.Persona).WithMany(p => p.Calificaciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__perso__5629CD9C");

            entity.HasOne(d => d.Producto).WithMany(p => p.Calificaciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__produ__571DF1D5");
        });

        modelBuilder.Entity<DetallesDevolucione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Detalles__3213E83F099129C3");

            entity.HasOne(d => d.Devolucion).WithMany(p => p.DetallesDevoluciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalles___devol__5812160E");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallesDevoluciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalles___produ__59063A47");
        });

        modelBuilder.Entity<DetallesPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Detalles__3213E83F58C3F886");

            entity.HasOne(d => d.Pedido).WithMany(p => p.DetallesPedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalles___pedid__59FA5E80");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallesPedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalles___produ__5AEE82B9");
        });

        modelBuilder.Entity<DetallesPromocione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Detalles__3213E83F36F44706");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallesPromociones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalles___produ__5BE2A6F2");

            entity.HasOne(d => d.Promocion).WithMany(p => p.DetallesPromociones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalles___promo__5CD6CB2B");
        });

        modelBuilder.Entity<DetallesReembolso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Detalles__3213E83F48CA1B29");

            entity.HasOne(d => d.DetalleDevolucion).WithMany(p => p.DetallesReembolsos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalles___detal__00200768");
        });

        modelBuilder.Entity<Devolucione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Devoluci__3213E83FBEA54BD4");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Devoluciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Devolucio__pedid__01142BA1");

            entity.HasOne(d => d.Persona).WithMany(p => p.Devoluciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Devolucio__perso__02084FDA");
        });

        modelBuilder.Entity<Envio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Envios__3213E83F5D042979");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Envios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Envios__pedido_i__02FC7413");
        });

        modelBuilder.Entity<Imagene>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Imagenes__3213E83FC3B2BBC3");

            entity.HasOne(d => d.Producto).WithMany(p => p.Imagenes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Imagenes__produc__03F0984C");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedidos__3213E83F54642F15");

            entity.HasOne(d => d.Persona).WithMany(p => p.Pedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__persona__04E4BC85");
        });

        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.ToView("Perfil");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persona__3213E83F76481B51");

            entity.HasOne(d => d.IdtipodocumentoNavigation).WithMany(p => p.Personas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Persona__idtipod__05D8E0BE");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3213E83FC763851A");
        });

        modelBuilder.Entity<Promocione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promocio__3213E83FC5DDB293");
        });

        modelBuilder.Entity<ProveedorProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proveedo__3213E83FB0242E73");

            entity.HasOne(d => d.Productos).WithMany(p => p.ProveedorProductos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProveedorProducto_Productos");

            entity.HasOne(d => d.Proveedores).WithMany(p => p.ProveedorProductos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProveedorProducto_Proveedores");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proveedo__3213E83F08A8E900");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rol__3213E83F4AB9F8D7");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoDocu__3213E83F105930D2");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83F1A5F3E56");

            entity.HasOne(d => d.Persona).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__persona__06CD04F7");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__rol_id__07C12930");
        });

        modelBuilder.Entity<VwDevolucione>(entity =>
        {
            entity.ToView("VW_Devoluciones");
        });

        modelBuilder.Entity<VwProducto>(entity =>
        {
            entity.ToView("VW_Producto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
