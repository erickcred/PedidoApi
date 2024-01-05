namespace Pedido.Infra.Request;

public class TelefoneRequest
{
  public int Id { get; set; }
  public string Numero { get; set; }
  public string Descricao { get; set; }
  public int UsuarioId { get; set; }
}