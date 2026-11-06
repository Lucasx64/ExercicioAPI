using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Contexts;

public partial class PizzariaContext : DbContext
{
    public PizzariaContext(DbContextOptions<PizzariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Entregador> Entregador { get; set; }

    public virtual DbSet<ItemPedido> ItemPedido { get; set; }

    public virtual DbSet<Pedido> Pedido { get; set; }

    public virtual DbSet<Pizza> Pizza { get; set; }

    public virtual DbSet<TelefoneCliente> TelefoneCliente { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CpfCliente).HasName("PK__CLIENTE__F6D70CA1C228F4ED");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.CpfCliente)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cpf_cliente");
            entity.Property(e => e.Bairro)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("bairro");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("numero");
            entity.Property(e => e.Rua)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("rua");
        });

        modelBuilder.Entity<Entregador>(entity =>
        {
            entity.HasKey(e => e.Matricula).HasName("PK__ENTREGAD__30962D145F217745");

            entity.ToTable("ENTREGADOR");

            entity.HasIndex(e => e.PlacaMoto, "UQ_ENTREGADOR_placa").IsUnique();

            entity.Property(e => e.Matricula)
                .ValueGeneratedNever()
                .HasColumnName("matricula");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.PlacaMoto)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("placa_moto");
        });

        modelBuilder.Entity<ItemPedido>(entity =>
        {
            entity.HasKey(e => e.CodigoPedido).HasName("PK__ITEM_PED__BBD0C51B35708D30");

            entity.ToTable("ITEM_PEDIDO");

            entity.Property(e => e.CodigoPedido).HasColumnName("codigo_pedido");
            entity.Property(e => e.CodigoCrip)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .IsFixedLength()
                .HasColumnName("codigo_crip");
            entity.Property(e => e.CodigoPizza).HasColumnName("codigo_pizza");
            entity.Property(e => e.NumeroPedido).HasColumnName("numero_pedido");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");

            entity.HasOne(d => d.CodigoPizzaNavigation).WithMany(p => p.ItemPedido)
                .HasForeignKey(d => d.CodigoPizza)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ITEM_PIZZA");

            entity.HasOne(d => d.NumeroPedidoNavigation).WithMany(p => p.ItemPedido)
                .HasForeignKey(d => d.NumeroPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ITEM_PEDIDO");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Numero).HasName("PK__PEDIDO__FC77F21099E39F98");

            entity.ToTable("PEDIDO");

            entity.Property(e => e.Numero)
                .ValueGeneratedNever()
                .HasColumnName("numero");
            entity.Property(e => e.CpfCliente)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cpf_cliente");
            entity.Property(e => e.DataPedido).HasColumnName("data_pedido");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.MatriculaEntregador).HasColumnName("matricula_entregador");

            entity.HasOne(d => d.CpfClienteNavigation).WithMany(p => p.Pedido)
                .HasForeignKey(d => d.CpfCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEDIDO_CLIENTE");

            entity.HasOne(d => d.MatriculaEntregadorNavigation).WithMany(p => p.Pedido)
                .HasForeignKey(d => d.MatriculaEntregador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEDIDO_ENTREGADOR");
        });

        modelBuilder.Entity<Pizza>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__PIZZA__40F9A207733629BB");

            entity.ToTable("PIZZA");

            entity.HasIndex(e => e.Sabor, "UQ_PIZZA_sabor").IsUnique();

            entity.Property(e => e.Codigo)
                .ValueGeneratedNever()
                .HasColumnName("codigo");
            entity.Property(e => e.Preco)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("preco");
            entity.Property(e => e.Sabor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sabor");
        });

        modelBuilder.Entity<TelefoneCliente>(entity =>
        {
            entity.HasKey(e => new { e.CpfCliente, e.Telefone }).HasName("PK_TELEFONE");

            entity.ToTable("TELEFONE_CLIENTE");

            entity.Property(e => e.CpfCliente)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cpf_cliente");
            entity.Property(e => e.Telefone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefone");

            entity.HasOne(d => d.CpfClienteNavigation).WithMany(p => p.TelefoneCliente)
                .HasForeignKey(d => d.CpfCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TELEFONE_CLIENTE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
