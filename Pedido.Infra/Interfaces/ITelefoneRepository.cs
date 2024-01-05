using Pedido.Domain.Entities;
using Pedido.Infra.Request;

namespace Pedido.Infra.Interfaces;

public interface ITelefoneRepository
{
  Task<IReadOnlyList<Telefone>> ListarTodos();
  Task<Telefone> Listar(int id);
  Task<List<Telefone>> Criar(List<TelefoneRequest> model);
  Task<Telefone> Atualizar(TelefoneRequest model);
}