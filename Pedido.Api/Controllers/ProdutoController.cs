using Microsoft.AspNetCore.Mvc;
using Pedido.Domain.Entities;
using Pedido.Infra.Interfaces;
using Pedido.Infra.Request;

namespace Pedido.Api.Controllers;

[Route("[controller]")]
public class ProdutoController : ControllerBase
{
  private readonly ILogger<ProdutoController> _logger;
  private readonly IProdutoRepository _produtoRepo;

  public ProdutoController(
    ILogger<ProdutoController> logger,
    IProdutoRepository produtoRepo
  )
  {
    _logger = logger;
    _produtoRepo = produtoRepo;
  }

  [HttpGet()]
  public async Task<IActionResult> ListarTodos()
  {
    var produtos = await _produtoRepo.ListarTodos();
    return Ok(produtos);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> Listar(int id)
  {
    var produto = await _produtoRepo.Listar(id);
    return Ok(produto);
  }

  [HttpPost]
  public async Task<IActionResult> Cria([FromBody] ProdutoRequest model)
  {
    var produto = await _produtoRepo.Criar(model);
    return Ok(produto);
  }

  [HttpPut]
  public async Task<IActionResult> Atualizar([FromBody] ProdutoRequest model)
  {
    var produto = await _produtoRepo.Atualizar(model);
    return Ok(produto);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Deletar(int id)
  {
    var produto = await _produtoRepo.Deletar(id);
    return Ok(produto);
  }

}