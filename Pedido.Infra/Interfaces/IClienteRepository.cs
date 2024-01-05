using Pedido.Domain.Entities;
using Pedido.Infra.Request;

namespace Pedido.Infra.Interfaces;

public interface IClienteRepository
{
  Task<IReadOnlyList<Usuario>> ListarTodos();
  Task<Usuario> Listar(int id);
  Task<Usuario> Criar(ClienteRequest model);
  Task<Usuario> Atualizar(ClienteRequest model);
  Task<Usuario> Deletar(int id);
}