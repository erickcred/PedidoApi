using System.ComponentModel.DataAnnotations.Schema;
using Pedido.Domain.Entities.enums;

namespace Pedido.Domain.Entities;

public class Usuario : EntidadeBase
{
  public string RazaoSocial { get; set; }
  public string Documento { get; set; }
  public TipoDocumento TipoDocumento { get; set; }
  public string NomeContato { get; set; }
  // public int TelefoneId { get; set; }
  public List<Telefone> Telefones { get; set; } = new();
  // public List<Endereco> Enderecos { get; set; }
  public bool Ativo { get; set; }

}