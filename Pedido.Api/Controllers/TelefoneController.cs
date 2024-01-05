using Microsoft.AspNetCore.Mvc;
using Pedido.Domain.Entities;
using Pedido.Infra.Interfaces;
using Pedido.Infra.Request;

namespace Pedido.Api.Controllers;

[Route("[controller]")]
public class TelefoneController : Controller
{
  private readonly ILogger<ClienteController> _logger;
  private readonly ITelefoneRepository _telefoneRepo;

  public TelefoneController(
    ILogger<ClienteController> logger,
    ITelefoneRepository telefoneRepo
  )
  {
    _logger = logger;
    _telefoneRepo = telefoneRepo;
  }

  [HttpGet()]
  public async Task<IActionResult> ListarTodos()
  {
    var telefones = await _telefoneRepo.ListarTodos();
    return Ok(telefones);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> Listar(int id)
  {
    var telefone = await _telefoneRepo.Listar(id);
    return Ok(telefone);
  }

  [HttpPost]
  public async Task<IActionResult> Cria([FromBody] List<TelefoneRequest> model)
  {
    var telefone = await _telefoneRepo.Criar(model);
    return Ok(telefone);
  }

  [HttpPut]
  public async Task<IActionResult> Atualizar([FromBody] TelefoneRequest model)
  {
    var telefone = await _telefoneRepo.Atualizar(model);
    return Ok(telefone);
  }

}