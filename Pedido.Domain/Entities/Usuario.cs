using Pedido.Domain.Entities.enums;

namespace Pedido.Domain.Entities;

public class Usuario : EntidadeBase
{
  public string RazaoSocial { get; set; }
  public string Documento { get; set; }
  public TipoDocumento TipoDocumento { get; set; }
  public int TelefoneId { get; set; }
  public Telefone Telefone { get; set; }
  public List<Endereco> Endereco { get; set; }
}