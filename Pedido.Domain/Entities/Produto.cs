namespace Pedido.Domain.Entities;
public class Produto : EntidadeBase
{
  public string Nome { get; set; }
  public int Quantidade { get; set; }
  public string Cor { get; set; }
  public string Descricao { get; set; }
  public decimal ValorUni { get; set; }
  public bool Ativo { get; set; }

  //public Produto(string nome, int quantidade, decimal valorUni, bool ativo)
  //{
  //  Nome = nome;
  //  Quantidade = quantidade;
  //  ValorUni = valorUni;
  //  Ativo = ativo;
  //}

  //public Produto(string nome, int quantidade, string cor, string descricao, decimal valorUni, bool ativo)
  //{
  //  Nome = nome;
  //  Quantidade = quantidade;
  //  Cor = cor;
  //  Descricao = descricao;
  //  ValorUni = valorUni;
  //  Ativo = ativo;
  //}
}