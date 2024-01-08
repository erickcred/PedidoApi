using Pedido.Domain.Entities;

namespace Pedido.Infra.Request;

public class ProdutoRequest
{
  public int Id { get; set; }
  public string Nome { get; set; }
  public int Quantidade { get; set; }
  public string Cor { get; set; }
  public string Descricao { get; set; }
  public decimal ValorUni { get; set; }
  public bool Ativo { get; set; }
  public int PedidoId { get; set; }

}