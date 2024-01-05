namespace Pedido.Domain.Entities;

public class Telefone : EntidadeBase
{
  public string Numero { get; set; }
  public string Descricao { get; set; }
  public int UsuarioId { get; set; }
  public Usuario Usuario { get; set; }
}