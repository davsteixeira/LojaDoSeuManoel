using LojaDoSeuManoel.Dtos;
using LojaDoSeuManoel.Models;
using LojaDoSeuManoel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Embalagem.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmbalagemController : ControllerBase
{
    private readonly EmbalagemService _service;

    public EmbalagemController(EmbalagemService service)
    {
        _service = service;
    }

    [HttpPost]
    public ActionResult<List<PedidoResponse>> Post(List<PedidoRequest> pedidos)
    {
        var resposta = new List<PedidoResponse>();

        foreach (var pedido in pedidos)
        {
            var produtos = pedido.Produtos.Select(p => new Produto
            {
                Nome = p.Nome,
                Altura = p.Altura,
                Largura = p.Largura,
                Comprimento = p.Comprimento
            }).ToList();

            var caixasComProdutos = _service.Embalar(produtos);

            var pedidoResposta = new PedidoResponse
            {
                PedidoId = pedido.Id,
                Caixas = caixasComProdutos.Select(c => new CaixaResponse
                {
                    Nome = c.caixa.Nome,
                    Produtos = c.produtos.Select(p => new ProdutoDto
                    {
                        Nome = p.Nome,
                        Altura = p.Altura,
                        Largura = p.Largura,
                        Comprimento = p.Comprimento
                    }).ToList()
                }).ToList()
            };

            resposta.Add(pedidoResposta);
        }

        return Ok(resposta);
    }
}
