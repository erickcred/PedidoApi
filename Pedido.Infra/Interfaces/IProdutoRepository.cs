using Pedido.Domain.Entities;
using Pedido.Infra.Request;

namespace Pedido.Infra.Interfaces;

public interface IProdutoRepository
{
  Task<IReadOnlyList<Produto>> ListarTodos();
  Task<Produto> Listar(int id);
  Task<Produto> Criar(ProdutoRequest model);
  Task<Produto> Atualizar(ProdutoRequest model);
  Task<Produto> Deletar(int id);
}