using Microsoft.EntityFrameworkCore;
using Pedido.Domain.Entities;
using Pedido.Infra.Contexts;
using Pedido.Infra.Interfaces;
using Pedido.Infra.Request;

namespace Pedido.Infra.Implementations;

public class ClienteRepository : IClienteRepository
{
  private PedidoContext _context;

  public ClienteRepository(PedidoContext context)
  {
    _context = context;
  }

  public async Task<IReadOnlyList<Usuario>> ListarTodos()
  {
    return await _context.Clientes
          .AsNoTracking()
          .Include(x => x.Telefones)
          .Where(x => x.Ativo)
          .ToListAsync();
  }

  public async Task<Usuario> Listar(int id)
  {
    try
    {
      var usuario = await _context.Clientes
            .AsNoTracking()
            .Include(x => x.Telefones)
            .Where(x => x.Ativo)
            .FirstOrDefaultAsync(x => x.Id == id);
      if (usuario != null)
      {
        return usuario;
      }
      return null;
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<Usuario> Criar(ClienteRequest model)
  {
    try
    {
      var usuario = new Usuario
      {
        RazaoSocial = model.RazaoSocial,
        Documento = model.Documento,
        TipoDocumento = model.TipoDocumento,
        NomeContato = model.NomeContato,
        Ativo = true
      };

      await _context.Clientes.AddAsync(usuario);
      await _context.SaveChangesAsync();

      return usuario;
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<Usuario> Atualizar(ClienteRequest model)
  {
    try
    {
      var usuario = await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == model.Id);

      if (usuario != null)
      {
        usuario.RazaoSocial = model.RazaoSocial;
        usuario.Documento = model.Documento;
        usuario.TipoDocumento = model.TipoDocumento;
        usuario.NomeContato = model.NomeContato;
        usuario.Ativo = model.Ativo;

        _context.Clientes.Update(usuario);
        await _context.SaveChangesAsync();
      }
      return null;
    } catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<Usuario> Deletar(int id)
  {
    var usuario = await _context.Clientes.FirstOrDefaultAsync(p => p.Id == id);
    if (usuario != null)
    {
      usuario.Ativo = false;
      _context.Clientes.Update(usuario);
      await _context.SaveChangesAsync();
      return usuario;
    }
    return usuario;
  }

}