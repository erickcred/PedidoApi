using Pedido.Domain.Entities;

namespace Pedido.Infra.Interfaces;

public interface IProdutoRepository
{
  Task<IReadOnlyList<Produto>> ListarTodos();
  Task<Produto> Listar(int id);
  Task<Produto> Criar(Produto model);
  Task<Produto> Atualizar(Produto model);
  Task<Produto> Deletar(int id);
}