using Microsoft.EntityFrameworkCore;
using Pedido.Domain.Entities;
using Pedido.Infra.Contexts;
using Pedido.Infra.Interfaces;

namespace Pedido.Infra.Implementations;

public class ProdutoRepository : IProdutoRepository
{
  private PedidoContext _context;

  public ProdutoRepository(PedidoContext context)
  {
    _context = context;
  }

  public async Task<IReadOnlyList<Produto>> ListarTodos()
  {
    return await _context.Produtos
          .AsNoTracking()
          .Where(x => x.Ativo)
          .ToListAsync();
  }

  public async Task<Produto> Listar(int id)
  {
    try
    {
      var produto = await _context.Produtos
            .AsNoTracking()
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

  public async Task<Produto> Atualizar(Produto model)
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

  public async Task<Produto> Criar(Produto model)
  {
    try
    {
      var produto = new Produto
      {
        Nome = model.Nome,
        Quantidade = model.Quantidade,
        Cor = model.Cor,
        Descricao = model.Descricao,
        ValorUni = model.ValorUni,
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