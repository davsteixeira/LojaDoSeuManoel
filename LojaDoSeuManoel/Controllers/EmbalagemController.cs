using LojaDoSeuManoel.Dtos;
using LojaDoSeuManoel.Models;
using LojaDoSeuManoel.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoSeuManoel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EmbalagemController : ControllerBase
    {
        private readonly EmbalagemService _service;

        public EmbalagemController(EmbalagemService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<List<PedidoResponseDto>> Post([FromBody] RequisicaoPedidosDto requisição)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resposta = new List<PedidoResponseDto>();

            foreach (var pedido in requisição.Pedidos)
            {
                var produtos = pedido.Produtos.Select(p => new Produto
                {
                    Produto_Id = p.Produto_Id,
                    Nome = p.Produto_Id,
                    Altura = p.Dimensoes.Altura,
                    Largura = p.Dimensoes.Largura,
                    Comprimento = p.Dimensoes.Comprimento
                }).ToList();

                var caixasComProdutos = _service.Embalar(produtos);

                var pedidoResposta = new PedidoResponseDto
                {
                    Pedido_Id = pedido.Pedido_Id,
                    Caixas = caixasComProdutos.Select(c =>
                    {
                        var caixaResponse = new CaixaResponseDto
                        {
                            Caixa_Id = c.produtos.Count == 0 ? null : c.caixa?.Nome,
                            Produtos = c.produtos.Select(p => p.Nome).ToList(),
                        };

                        if (c.produtos.Count == 0)
                        {
                            caixaResponse.Observacao = "Produto não cabe em nenhuma caixa disponível.";
                        }

                        return caixaResponse;
                    }).ToList()
                };

                resposta.Add(pedidoResposta);
            }

            return Ok(resposta);
        }


    }
}

