namespace Pedido.Domain.Entities;

public class PedidoE : EntidadeBase
{
  public string NumeroPedido { get; set; }
  public DateTime DataEmissao { get; set; }
  public DateTime DataChegada { get; set; }
  public DateTime PrevisaoEntrega { get; set; }
  public int ClienteId { get; set; }
  public Usuario Cliente{ get; set; }
  public List<Produto> Produtos { get; set; }
  public bool Finalizado { get; set; }
}