namespace Pedido.Infra.Request;

public class PedidoRequest
{
  public int Id { get; set; }
  public string NumeroPedido { get; set; }
  public DateTime DataEmissao { get; set; }
  public DateTime DataChegada { get; set; }
  public DateTime PrevisaoEntrega { get; set; }
  public int ClienteId { get; set; }

  public PedidoRequest(
    string numeroPedido,
    DateTime dataEmissao,
    DateTime previsaoEntrega,
    int clienteId
  )
  {
    NumeroPedido = numeroPedido;
    DataEmissao = dataEmissao;
    PrevisaoEntrega = previsaoEntrega;
    ClienteId = clienteId;
  }

  public DateTime SetaData()
  {
    return DateTime.Now;
  }
  
}