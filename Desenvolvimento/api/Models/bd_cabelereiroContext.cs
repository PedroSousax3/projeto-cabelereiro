using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Models
{
    public partial class bd_cabelereiroContext : DbContext
    {
        public bd_cabelereiroContext()
        {
        }

        public bd_cabelereiroContext(DbContextOptions<bd_cabelereiroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAgenda> TbAgenda { get; set; }
        public virtual DbSet<TbCliente> TbCliente { get; set; }
        public virtual DbSet<TbCorte> TbCorte { get; set; }
        public virtual DbSet<TbEstoque> TbEstoque { get; set; }
        public virtual DbSet<TbFuncionario> TbFuncionario { get; set; }
        public virtual DbSet<TbProduto> TbProduto { get; set; }
        public virtual DbSet<TbVenda> TbVenda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user id=root;password=45923617xx;database=bd_cabelereiro", x => x.ServerVersion("8.0.20-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAgenda>(entity =>
            {
                entity.HasKey(e => e.IdAgenda)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("id_cliente");

                entity.HasIndex(e => e.IdFuncionario)
                    .HasName("id_funcionario");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbAgenda)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("tb_agenda_ibfk_2");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.TbAgenda)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("tb_agenda_ibfk_1");
            });

            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsCpf)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsEmail)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsTel)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmCliente)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbCorte>(entity =>
            {
                entity.HasKey(e => e.IdCorte)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdFuncionario)
                    .HasName("id_funcionario");

                entity.Property(e => e.DsComentario)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsDicas)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsFoto)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmCorte)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TpCorte)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.TbCorte)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("tb_corte_ibfk_1");
            });

            modelBuilder.Entity<TbEstoque>(entity =>
            {
                entity.HasKey(e => e.IdEstoque)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdProduto)
                    .HasName("id_produto");

                entity.HasIndex(e => e.IdVenda)
                    .HasName("id_venda");

                entity.Property(e => e.DsMotivo)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.TbEstoque)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_estoque_ibfk_1");

                entity.HasOne(d => d.IdVendaNavigation)
                    .WithMany(p => p.TbEstoque)
                    .HasForeignKey(d => d.IdVenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_estoque_ibfk_2");
            });

            modelBuilder.Entity<TbFuncionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsCep)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsComplemento)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsCpf)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsCurriculo)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsEmail)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsEndereco)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsFoto)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsSenha)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsTel)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmFuncionario)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmUsuario)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TpCargo)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbProduto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsNotaFical)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsUnidadeMedida)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmMarca)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmProduto)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbVenda>(entity =>
            {
                entity.HasKey(e => e.IdVenda)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("id_cliente");

                entity.HasIndex(e => e.IdCorte)
                    .HasName("id_corte");

                entity.HasIndex(e => e.IdFuncionario)
                    .HasName("id_funcionario");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbVenda)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("tb_venda_ibfk_2");

                entity.HasOne(d => d.IdCorteNavigation)
                    .WithMany(p => p.TbVenda)
                    .HasForeignKey(d => d.IdCorte)
                    .HasConstraintName("tb_venda_ibfk_3");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.TbVenda)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("tb_venda_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
