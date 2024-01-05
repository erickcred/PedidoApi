using Microsoft.EntityFrameworkCore;
using Pedido.Domain.Entities;
using Pedido.Infra.Contexts;
using Pedido.Infra.Interfaces;
using Pedido.Infra.Request;

namespace Pedido.Infra.Implementations;

public class TelefoneRepository : ITelefoneRepository
{
  private PedidoContext _context;

  public TelefoneRepository(PedidoContext context)
  {
    _context = context;
  }

  public async Task<IReadOnlyList<Telefone>> ListarTodos()
  {
    return await _context.Telefones
          .AsNoTracking()
          .ToListAsync();
  }

  public async Task<Telefone> Listar(int id)
  {
    try
    {
      var telefone = await _context.Telefones
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
      if (telefone != null)
      {
        return telefone;
      }
      return null;
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<List<Telefone>> Criar(List<TelefoneRequest> model)
  {
    List<Telefone> telefones = new();
    try
    {
      var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == model[0].UsuarioId);
      if (cliente == null ) throw new Exception("Erro ao localizar o cliente para registrar o telefone!");
      
      model.ForEach(item => {
        telefones.Add(new Telefone()
        {
          Numero = item.Numero,
          Descricao = item.Descricao,
          UsuarioId = item.UsuarioId,
          Usuario = cliente
        });
      });

      await _context.Telefones.AddRangeAsync(telefones);
      await _context.SaveChangesAsync();

      return telefones;
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<Telefone> Atualizar(TelefoneRequest model)
  {
    try
    {
      var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == model.UsuarioId);
      if (cliente == null ) throw new Exception("Erro ao localizar o cliente para registrar o telefone!");
      
      var telefone = await _context.Telefones.AsNoTracking().FirstOrDefaultAsync(x => x.Id == model.Id);

      if (telefone != null)
      {
        telefone.Numero = model.Numero;
        telefone.Descricao = model.Descricao;
        telefone.UsuarioId = cliente.Id;
        telefone.Usuario = cliente;

        _context.Telefones.Update(telefone);
        await _context.SaveChangesAsync();
      }
      return null;
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

}