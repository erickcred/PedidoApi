﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pedido.Infra.Contexts;

#nullable disable

namespace Pedido.Infra.Migrations
{
    [DbContext(typeof(PedidoContext))]
    partial class PedidoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Pedido.Domain.Entities.PedidoE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("Int")
                        .HasColumnName("ClienteId");

                    b.Property<DateTime>("DataChegada")
                        .HasColumnType("DateTime")
                        .HasColumnName("DataChegada");

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("DateTime")
                        .HasColumnName("DateEmissao");

                    b.Property<sbyte>("Finalizado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Tinyint")
                        .HasDefaultValue((sbyte)0)
                        .HasColumnName("Finalizado");

                    b.Property<string>("NumeroPedido")
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("NumeroPedido");

                    b.Property<DateTime>("PrevisaoEntrega")
                        .HasColumnType("DateTime")
                        .HasColumnName("PrevisaoEntrega");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("Pedido.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<sbyte>("Ativo")
                        .HasColumnType("Tinyint")
                        .HasColumnName("Ativo");

                    b.Property<string>("Cor")
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("Cor");

                    b.Property<string>("Descricao")
                        .HasColumnType("Text")
                        .HasColumnName("Descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(255)")
                        .HasColumnName("Nome");

                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Int")
                        .HasDefaultValue(0)
                        .HasColumnName("PedidoId");

                    b.Property<int>("Quantidade")
                        .HasColumnType("Int")
                        .HasColumnName("Quantidade");

                    b.Property<decimal>("ValorUni")
                        .HasColumnType("Decimal(9,2)")
                        .HasColumnName("ValorUni");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("Pedido.Domain.Entities.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("Varchar(255)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("Varchar(25)")
                        .HasColumnName("Numero");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("Int")
                        .HasColumnName("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Telefone", (string)null);
                });

            modelBuilder.Entity("Pedido.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<sbyte>("Ativo")
                        .HasColumnType("Tinyint")
                        .HasColumnName("Ativo");

                    b.Property<string>("Documento")
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Documento");

                    b.Property<string>("NomeContato")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("NomeContato");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("Varchar(200)")
                        .HasColumnName("RazaoSocial");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("Enum('CPF', 'CNPJ')")
                        .HasColumnName("TipoDocumento");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("Pedido.Domain.Entities.PedidoE", b =>
                {
                    b.HasOne("Pedido.Domain.Entities.Usuario", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Pedido.Domain.Entities.Produto", b =>
                {
                    b.HasOne("Pedido.Domain.Entities.PedidoE", "Pedido")
                        .WithMany("Produtos")
                        .HasForeignKey("PedidoId");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Pedido.Domain.Entities.Telefone", b =>
                {
                    b.HasOne("Pedido.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Telefones")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Pedido.Domain.Entities.PedidoE", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Pedido.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Telefones");
                });
#pragma warning restore 612, 618
        }
    }
}
