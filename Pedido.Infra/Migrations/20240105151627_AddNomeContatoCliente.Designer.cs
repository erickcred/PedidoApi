﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pedido.Infra.Contexts;

#nullable disable

namespace Pedido.Infra.Migrations
{
    [DbContext(typeof(PedidoContext))]
    [Migration("20240105151627_AddNomeContatoCliente")]
    partial class AddNomeContatoCliente
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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

                    b.Property<int>("Quantidade")
                        .HasColumnType("Int")
                        .HasColumnName("Quantidade");

                    b.Property<decimal>("ValorUni")
                        .HasColumnType("Decimal(9,2)")
                        .HasColumnName("ValorUni");

                    b.HasKey("Id");

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

            modelBuilder.Entity("Pedido.Domain.Entities.Telefone", b =>
                {
                    b.HasOne("Pedido.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Telefones")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Pedido.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Telefones");
                });
#pragma warning restore 612, 618
        }
    }
}
