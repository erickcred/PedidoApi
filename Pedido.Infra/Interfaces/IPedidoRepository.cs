using Pedido.Domain.Entities;
using Pedido.Infra.Request;

namespace Pedido.Infra.Interfaces;

public interface IPedidoRepository
{
  Task<IReadOnlyList<PedidoE>> ListarTodos();
  Task<PedidoE> Listar(int id);
  Task<PedidoE> Criar(PedidoRequest model);
  Task<PedidoE> Atualizar(PedidoRequest model);
  Task<PedidoE> Finalizar(int id);
}