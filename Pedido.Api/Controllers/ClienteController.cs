using Microsoft.AspNetCore.Mvc;
using Pedido.Domain.Entities;
using Pedido.Infra.Interfaces;
using Pedido.Infra.Request;

namespace Pedido.Api.Controllers;

[Route("[controller]")]
public class ClienteController : Controller
{
  private readonly ILogger<ClienteController> _logger;
  private readonly IClienteRepository _clienteRepo;

  public ClienteController(
    ILogger<ClienteController> logger,
    IClienteRepository clienteRepo
  )
  {
    _logger = logger;
    _clienteRepo = clienteRepo;
  }

  [HttpGet()]
  public async Task<IActionResult> ListarTodos()
  {
    var clientes = await _clienteRepo.ListarTodos();
    return Ok(clientes);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> Listar(int id)
  {
    var cliente = await _clienteRepo.Listar(id);
    return Ok(cliente);
  }

  [HttpPost]
  public async Task<IActionResult> Cria([FromBody] ClienteRequest model)
  {
    var cliente = await _clienteRepo.Criar(model);
    return Ok(cliente);
  }

  [HttpPut]
  public async Task<IActionResult> Atualizar([FromBody] ClienteRequest model)
  {
    var cliente = await _clienteRepo.Atualizar(model);
    return Ok(cliente);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Deletar(int id)
  {
    var cliente = await _clienteRepo.Deletar(id);
    return Ok(cliente);
  }
 
}