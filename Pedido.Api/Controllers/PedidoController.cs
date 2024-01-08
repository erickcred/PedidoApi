using Microsoft.AspNetCore.Mvc;
using Pedido.Infra.Interfaces;
using Pedido.Infra.Request;

namespace Pedido.Api.Controllers;

[Route("[controller]")]
public class PedidoController : Controller
{
  private readonly ILogger<PedidoController> _logger;
  private readonly IPedidoRepository _pedidoRepo;

  public PedidoController(
    ILogger<PedidoController> logger,
    IPedidoRepository pedidoRepo
  )
  {
    _logger = logger;
    _pedidoRepo = pedidoRepo;
  }

  [HttpGet()]
  public async Task<IActionResult> ListarTodos()
  {
    var pedidos = await _pedidoRepo.ListarTodos();
    return Ok(pedidos);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> Listar(int id)
  {
    var pedido = await _pedidoRepo.Listar(id);
    return Ok(pedido);
  }

  [HttpPost]
  public async Task<IActionResult> Cria([FromBody] PedidoRequest model)
  {
    var pedido = await _pedidoRepo.Criar(model);
    return Ok(pedido);
  }

  [HttpPut]
  public async Task<IActionResult> Atualizar([FromBody] PedidoRequest model)
  {
    var pedido = await _pedidoRepo.Atualizar(model);
    return Ok(pedido);
  }

  [HttpPut("Finalizar/{id}")]
  public async Task<IActionResult> Finalizar(int id)
  {
    var pedido = await _pedidoRepo.Finalizar(id);
    return Ok(pedido);
  }
}
