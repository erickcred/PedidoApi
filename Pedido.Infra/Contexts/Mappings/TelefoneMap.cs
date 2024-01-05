using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedido.Domain.Entities;

namespace Pedido.Infra.Contexts.Mappings;

public class TelefoneMap : IEntityTypeConfiguration<Telefone>
{
  public void Configure(EntityTypeBuilder<Telefone> telefone)
  {
    telefone.ToTable("Telefone");
    telefone.HasKey(x => x.Id);
    telefone.Property(x => x.Id).ValueGeneratedOnAdd();

    telefone.Property(x => x.Numero)
      .IsRequired()
      .HasColumnName("Numero")
      .HasColumnType("Varchar(25)");

    telefone.Property(x => x.Descricao)
      .IsRequired()
      .HasColumnName("Descricao")
      .HasColumnType("Varchar(255)");

    telefone.Property(x => x.UsuarioId)
      .IsRequired()
      .HasColumnName("UsuarioId")
      .HasColumnType("Int");

    telefone.HasOne(x => x.Usuario)
      .WithMany(x => x.Telefones)
      .IsRequired();

  }
}