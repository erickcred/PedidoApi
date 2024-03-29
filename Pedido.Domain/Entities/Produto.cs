using System.ComponentModel.DataAnnotations.Schema;

namespace Pedido.Domain.Entities;
public class Produto : EntidadeBase
{
  public string Nome { get; set; }
  public int Quantidade { get; set; }
  public string Cor { get; set; }
  public string Descricao { get; set; }
  public decimal ValorUni { get; set; }
  public bool Ativo { get; set; }
  public int PedidoId { get; set; }

  [NotMapped]
  public PedidoE Pedido { get; set; }

}