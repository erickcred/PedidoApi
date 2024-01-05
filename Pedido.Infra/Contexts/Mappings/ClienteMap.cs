using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedido.Domain.Entities;

namespace Pedido.Infra.Contexts.Mappings;

public class ClienteMap : IEntityTypeConfiguration<Usuario>
{
  public void Configure(EntityTypeBuilder<Usuario> cliente)
  {
    cliente.ToTable("Cliente");
    cliente.HasKey(x => x.Id);
    cliente.Property(x => x.Id).ValueGeneratedOnAdd();

    cliente.Property(x => x.RazaoSocial)
      .IsRequired(false)
      .HasColumnName("RazaoSocial")
      .HasColumnType("Varchar(200)");

    cliente.Property(x => x.Documento)
      .IsRequired(false)
      .HasColumnName("Documento")
      .HasColumnType("Varchar(50)");

    cliente.Property(x => x.NomeContato)
      .IsRequired()
      .HasColumnName("NomeContato")
      .HasColumnType("Varchar(100)");

    cliente.Property(x => x.Ativo)
      .HasColumnName("Ativo")
      .HasColumnType("Tinyint");

    cliente.Property(x => x.TipoDocumento)
      .HasColumnName("TipoDocumento")
      .HasColumnType("Enum('CPF', 'CNPJ')");


  }
}