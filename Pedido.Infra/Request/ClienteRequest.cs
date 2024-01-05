using Pedido.Domain.Entities.enums;

namespace Pedido.Infra.Request;

public class ClienteRequest
{
  public int Id { get; set; }
  public string RazaoSocial { get; set; }
  public string Documento { get; set; }
  public string NomeContato { get; set; }
  public TipoDocumento TipoDocumento { get; set; }
  public bool Ativo { get; set; }
}
