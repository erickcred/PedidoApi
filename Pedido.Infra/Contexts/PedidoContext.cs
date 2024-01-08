using Microsoft.EntityFrameworkCore;
using Pedido.Domain.Entities;
using Pedido.Infra.Contexts.Mappings;

namespace Pedido.Infra.Contexts;

public class PedidoContext : DbContext
{
  public PedidoContext(DbContextOptions<PedidoContext> options) : base(options) { }

  public DbSet<Produto> Produtos { get; set; }
  public DbSet<Usuario> Clientes { get; set; }
  public DbSet<Telefone> Telefones { get; set; }
  public DbSet<PedidoE> Pedidos { get; set; }

  

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfiguration(new ProdutoMap());
    modelBuilder.ApplyConfiguration(new ClienteMap());
    modelBuilder.ApplyConfiguration(new TelefoneMap());
    modelBuilder.ApplyConfiguration(new PedidoMap());
  }
}
