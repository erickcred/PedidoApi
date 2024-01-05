using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedido.Domain.Entities;

namespace Pedido.Infra.Contexts.Mappings;

public class ProdutoMap : IEntityTypeConfiguration<Produto>
{
  public void Configure(EntityTypeBuilder<Produto> produto)
  {
    produto.ToTable("Produto");
    produto.HasKey(x => x.Id);
    produto.Property(x => x.Id).ValueGeneratedOnAdd();

    produto.Property(x => x.Nome)
      .IsRequired()
      .HasColumnName("Nome")
      .HasColumnType("Varchar(255)");
    
    produto.Property(x => x.Quantidade)
      .IsRequired()
      .HasColumnName("Quantidade")
      .HasColumnType("Int");

    produto.Property(x => x.Cor)
      .IsRequired(false)
      .HasColumnName("Cor")
      .HasColumnType("Varchar(100)");

    produto.Property(x => x.Descricao)
      .IsRequired(false)
      .HasColumnName("Descricao")
      .HasColumnType("Text");

    produto.Property(x => x.ValorUni)
      .IsRequired()
      .HasColumnName("ValorUni")
      .HasColumnType("Decimal(9,2)");

    produto.Property(x => x.Ativo)
      .HasColumnName("Ativo")
      .HasColumnType("Tinyint");
  }
}