using Microsoft.EntityFrameworkCore;
using Pedido.Domain.Entities;
using Pedido.Infra.Contexts;
using Pedido.Infra.Interfaces;
using Pedido.Infra.Request;

namespace Pedido.Infra.Implementations;

public class ProdutoRepository : IProdutoRepository
{
  private readonly PedidoContext _context;

  public ProdutoRepository(PedidoContext context)
  {
    _context = context;
  }

  public async Task<IReadOnlyList<Produto>> ListarTodos()
  {
    return await _context.Produtos
          .AsNoTracking()
          .Include(x => x.Pedido)
          .Where(x => x.Ativo)
          .ToListAsync();
  }

  public async Task<Produto> Listar(int id)
  {
    try
    {
      var produto = await _context.Produtos
            .AsNoTracking()
            .Include(x => x.Pedido)
            .Where(x => x.Ativo)
            .FirstOrDefaultAsync(x => x.Id == id);
      if (produto != null)
      {
        return produto;
      }
      return null;
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<Produto> Criar(ProdutoRequest model)
  {
    try
    {
      var pedido = _context.Pedidos.FirstOrDefault(x => x.Id == model.PedidoId);
      Produto produto;
        produto = new Produto
        {
          Nome = model.Nome,
          Quantidade = model.Quantidade,
          Cor = model.Cor,
          Descricao = model.Descricao,
          ValorUni = model.ValorUni,
          PedidoId = model.PedidoId,
          Pedido = pedido,
          Ativo = true
        };

    await _context.Produtos.AddAsync(produto);
    await _context.SaveChangesAsync();
    return produto;
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<List<Produto>> Criar(List<ProdutoRequest> model)
  {
    var produtos = new List<Produto>();
    try
    {
      var pedido = _context.Pedidos.FirstOrDefault(x => x.Id == model[0].PedidoId);

      model.ForEach(item => {
        produtos.Add(new Produto{
          Nome = item.Nome,
          Quantidade = item.Quantidade,
          Cor = item.Cor,
          Descricao = item.Descricao,
          ValorUni = item.ValorUni,
          PedidoId = item.PedidoId,
          Pedido = pedido,
          Ativo = true
        });
      });

    await _context.Produtos.AddRangeAsync(produtos);
    await _context.SaveChangesAsync();
    return produtos;
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<Produto> Atualizar(ProdutoRequest model)
  {
    try
    {
      var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == model.Id);

      if (produto != null)
      {
        produto.Nome = model.Nome;
        produto.Quantidade = model.Quantidade;
        produto.Cor = model.Cor;
        produto.Descricao = model.Descricao;
        produto.ValorUni = model.ValorUni;
        produto.PedidoId = model.PedidoId;
        produto.Ativo = model.Ativo;

        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
      }
      return null;
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<Produto> Deletar(int id)
  {
    var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
    if (produto != null)
    {
      produto.Ativo = false;
      _context.Produtos.Update(produto);
      await _context.SaveChangesAsync();
      return produto;
    }
    return produto;
  }

}