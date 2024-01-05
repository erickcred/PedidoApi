namespace Pedido.Domain.Entities;
public class Endereco : EntidadeBase
{
  public string Cep { get; set; }
  public string Logradouro { get; set; }
  public string Complemento { get; set; }
  public string Bairro { get; set; }
  public string Localidade { get; set; }
  public string  Numero { get; set; }
  public string Uf { get; set; }
  public string Ibge { get; set; }
  public string Gia { get; set; }
  public string ddd { get; set; }
  public string Observacao { get; set; }
  public int UsuarioId { get; set; }
  public Usuario Usuario { get; set; }

}
