using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LeiloadosWebAPI.Domains;

#nullable disable

namespace LeiloadosWebAPI.Contexts
{
    public partial class LeiloadosContext : DbContext
    {
        public LeiloadosContext()
        {
        }

        public LeiloadosContext(DbContextOptions<LeiloadosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<Etiqueta> Etiquetas { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NOTE0111E6\\SQLEXPRESS; initial catalog=Classificados; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => e.IdComentario)
                    .HasName("PK__comentar__C74515DAD051076D");

                entity.ToTable("comentarios");

                entity.Property(e => e.IdComentario).HasColumnName("idComentario");

                entity.Property(e => e.BinarioImg).HasColumnName("binarioImg");

                entity.Property(e => e.Comentario1)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("comentario");

                entity.Property(e => e.IdClassificado).HasColumnName("idClassificado");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdClassificadoNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.IdClassificado)
                    .HasConstraintName("FK__comentari__idCla__2F10007B");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__comentari__idUsu__2E1BDC42");
            });

            modelBuilder.Entity<Etiqueta>(entity =>
            {
                entity.HasKey(e => e.IdEtiqueta)
                    .HasName("PK__etiqueta__3C1526A7E1739080");

                entity.ToTable("etiquetas");

                entity.Property(e => e.IdEtiqueta).HasColumnName("idEtiqueta");

                entity.Property(e => e.IdClassificado).HasColumnName("idClassificado");

                entity.Property(e => e.IdTag).HasColumnName("idTag");

                entity.HasOne(d => d.IdClassificadoNavigation)
                    .WithMany(p => p.Etiqueta)
                    .HasForeignKey(d => d.IdClassificado)
                    .HasConstraintName("FK__etiquetas__idCla__35BCFE0A");

                entity.HasOne(d => d.IdTagNavigation)
                    .WithMany(p => p.Etiqueta)
                    .HasForeignKey(d => d.IdTag)
                    .HasConstraintName("FK__etiquetas__idTag__34C8D9D1");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__pedidos__A9F619B7A1C43177");

                entity.ToTable("pedidos");

                entity.Property(e => e.IdPedido).HasColumnName("idPedido");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Pedido1)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("pedido");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__pedidos__idUsuar__2B3F6F97");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.IdTag)
                    .HasName("PK__tags__020FEDB8112147F2");

                entity.ToTable("tags");

                entity.HasIndex(e => e.NomeTag, "UQ__tags__77E2238E5D040247")
                    .IsUnique();

                entity.Property(e => e.IdTag).HasColumnName("idTag");

                entity.Property(e => e.NomeTag)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomeTag");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFFBE86B4E8");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__tipoUsua__A017BD9F1FFAA18B")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A64033303F");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E616469C60E0A")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.BinarioImg).HasColumnName("binarioImg");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Popularidade).HasColumnName("popularidade");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.Property(e => e.Telefone).HasColumnName("telefone");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
