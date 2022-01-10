using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Amedia.Model
{
    public partial class TestCrudContext : DbContext
    {
        public TestCrudContext()
        {
        }

        public TestCrudContext(DbContextOptions<TestCrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAlquiler> TAlquilers { get; set; }
        public virtual DbSet<TGenero> TGeneros { get; set; }
        public virtual DbSet<TGeneroPelicula> TGeneroPeliculas { get; set; }
        public virtual DbSet<TPelicula> TPeliculas { get; set; }
        public virtual DbSet<TRol> TRols { get; set; }
        public virtual DbSet<tUser> TUsers { get; set; }
        public virtual DbSet<TVenta> TVenta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=SSALAS-NOTE;Initial Catalog=TestCrud;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TAlquiler>(entity =>
            {
                entity.HasKey(e => e.IdAlquiler);

                entity.ToTable("tAlquiler");

                entity.Property(e => e.IdAlquiler).HasColumnName("id_alquiler");

                entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.Devolucion).HasColumnName("devolucion");

                entity.Property(e => e.FechaAlquiler)
                    .HasColumnType("date")
                    .HasColumnName("fecha_alquiler");

                entity.Property(e => e.PrecioAlquiler)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("precio_alquiler");

                entity.HasOne(d => d.CodPeliculaNavigation)
                    .WithMany(p => p.TAlquilers)
                    .HasForeignKey(d => d.CodPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tAlquiler_tPelicula");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.TAlquilers)
                    .HasForeignKey(d => d.CodUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tAlquiler_tUsers");
            });

            modelBuilder.Entity<TGenero>(entity =>
            {
                entity.HasKey(e => e.CodGenero)
                    .HasName("PK__tGenero__0DACB9D5D8E2CDAE");

                entity.ToTable("tGenero");

                entity.Property(e => e.CodGenero).HasColumnName("cod_genero");

                entity.Property(e => e.TxtDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("txt_desc");
            });

            modelBuilder.Entity<TGeneroPelicula>(entity =>
            {
                entity.HasKey(e => new { e.CodPelicula, e.CodGenero })
                    .HasName("PK__tGeneroP__6285A59515EBA182");

                entity.ToTable("tGeneroPelicula");

                entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");

                entity.Property(e => e.CodGenero).HasColumnName("cod_genero");

                entity.HasOne(d => d.CodGeneroNavigation)
                    .WithMany(p => p.TGeneroPeliculas)
                    .HasForeignKey(d => d.CodGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pelicula_genero");

                entity.HasOne(d => d.CodPeliculaNavigation)
                    .WithMany(p => p.TGeneroPeliculas)
                    .HasForeignKey(d => d.CodPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_genero_pelicula");
            });

            modelBuilder.Entity<TPelicula>(entity =>
            {
                entity.HasKey(e => e.CodPelicula)
                    .HasName("PK__tPelicul__225F6E08E1377DD3");

                entity.ToTable("tPelicula");

                entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");

                entity.Property(e => e.CantDisponiblesAlquiler).HasColumnName("cant_disponibles_alquiler");

                entity.Property(e => e.CantDisponiblesVenta).HasColumnName("cant_disponibles_venta");

                entity.Property(e => e.PrecioAlquiler)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("precio_alquiler");

                entity.Property(e => e.PrecioVenta)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("precio_venta");

                entity.Property(e => e.TxtDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("txt_desc");
            });

            modelBuilder.Entity<TRol>(entity =>
            {
                entity.HasKey(e => e.CodRol)
                    .HasName("PK__tRol__F13B12117775FD7B");

                entity.ToTable("tRol");

                entity.Property(e => e.CodRol).HasColumnName("cod_rol");

                entity.Property(e => e.SnActivo).HasColumnName("sn_activo");

                entity.Property(e => e.TxtDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("txt_desc");
            });

            modelBuilder.Entity<tUser>(entity =>
            {
                entity.HasKey(e => e.cod_usuario)
                    .HasName("PK__tUsers__EA3C9B1AA21FB561");

                entity.ToTable("tUsers");

                entity.Property(e => e.cod_usuario).HasColumnName("cod_usuario");

                entity.Property(e => e.cod_rol).HasColumnName("cod_rol");

                entity.Property(e => e.nro_doc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nro_doc");

                entity.Property(e => e.sn_activo).HasColumnName("sn_activo");

                entity.Property(e => e.txt_apellido)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("txt_apellido");

                entity.Property(e => e.txt_nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("txt_nombre");

                entity.Property(e => e.txt_password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txt_password");

                entity.Property(e => e.txt_user)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txt_user");

                entity.HasOne(d => d.CodRolNavigation)
                    .WithMany(p => p.tUsers)
                    .HasForeignKey(d => d.cod_rol)
                    .HasConstraintName("fk_user_rol");
            });

            modelBuilder.Entity<TVenta>(entity =>
            {
                entity.HasKey(e => e.IdVenta);

                entity.ToTable("tVenta");

                entity.Property(e => e.IdVenta)
                    .ValueGeneratedNever()
                    .HasColumnName("id_venta");

                entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.FechaVenta)
                    .HasColumnType("date")
                    .HasColumnName("fecha_venta");

                entity.Property(e => e.PrecioVenta)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("precio_venta");

                entity.HasOne(d => d.CodPeliculaNavigation)
                    .WithMany(p => p.TVenta)
                    .HasForeignKey(d => d.CodPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tVenta_tPelicula");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.TVenta)
                    .HasForeignKey(d => d.CodUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tVenta_tUsers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
