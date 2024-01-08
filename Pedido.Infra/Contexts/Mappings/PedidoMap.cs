using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedido.Domain.Entities;

namespace Pedido.Infra.Contexts.Mappings;

public class PedidoMap : IEntityTypeConfiguration<PedidoE>
{
  public void Configure(EntityTypeBuilder<PedidoE> pedido)
  {
    pedido.ToTable("Pedido");
    pedido.HasKey(x => x.Id);
    pedido.Property(x => x.Id).ValueGeneratedOnAdd();

    pedido.Property(x => x.NumeroPedido)
      .IsRequired(false)
      .HasColumnName("NumeroPedido")
      .HasColumnType("Varchar(50)");

    pedido.Property(x => x.DataEmissao)
      .HasColumnName("DateEmissao")
      .HasColumnType("DateTime");

    pedido.Property(x => x.DataChegada)
      .HasColumnName("DataChegada")
      .HasColumnType("DateTime");

    pedido.Property(x => x.PrevisaoEntrega)
      .HasColumnName("PrevisaoEntrega")
      .HasColumnType("DateTime");

    pedido.Property(x => x.ClienteId)
      .IsRequired(true)
      .HasColumnName("ClienteId")
      .HasColumnType("Int");

    pedido.HasMany(x => x.Produtos)
      .WithOne(x => x.Pedido)
      .IsRequired(false);

    pedido.Property(x => x.Finalizado)
      .HasColumnName("Finalizado")
      .HasColumnType("Tinyint")
      .HasDefaultValue(0);

  }
        
}