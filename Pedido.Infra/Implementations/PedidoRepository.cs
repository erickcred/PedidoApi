using Microsoft.EntityFrameworkCore;
using Pedido.Domain.Entities;
using Pedido.Infra.Contexts;
using Pedido.Infra.Interfaces;
using Pedido.Infra.Request;

namespace Pedido.Infra.Implementations;

public class PedidoRepository : IPedidoRepository
{
  private readonly PedidoContext _context;
  public PedidoRepository(PedidoContext context)
  {
      _context = context;
  }
  
  public async Task<IReadOnlyList<PedidoE>> ListarTodos()
  {
    return await _context.Pedidos
        .AsNoTracking()
        .ToListAsync();
  }

  public async Task<PedidoE> Listar(int id)
  {
    try
    {
      var pedido = await _context.Pedidos
            .AsNoTracking()
            .Include(x => x.Produtos)
            .FirstOrDefaultAsync(x => x.Id == id);
      if (pedido != null)
      {
        return pedido;
      }
      return null;
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<PedidoE> Criar(PedidoRequest model)
  {
    try
    {
      var pedido = new PedidoE
      {
        NumeroPedido = model.NumeroPedido,
        DataEmissao = model.DataEmissao,
        DataChegada = model.SetaData(),
        PrevisaoEntrega = model.PrevisaoEntrega,
        ClienteId = model.ClienteId,
      };

      await _context.Pedidos.AddAsync(pedido);
      await _context.SaveChangesAsync();

      return pedido;
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<PedidoE> Atualizar(PedidoRequest model)
  {
    try
    {
      var pedido = await _context.Pedidos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == model.Id);

      if (pedido != null)
      {
        pedido.NumeroPedido = model.NumeroPedido;
        pedido.DataEmissao = model.DataEmissao;
        pedido.PrevisaoEntrega = model.PrevisaoEntrega;
        pedido.ClienteId = model.ClienteId;

        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
      }
      return null;
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<PedidoE> Finalizar(int id)
  {
    try
    {
      var pedido = await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == id);
      if (pedido != null)
      {
        pedido.Finalizado = false;
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
        return pedido;
      }
      return pedido;

    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
}