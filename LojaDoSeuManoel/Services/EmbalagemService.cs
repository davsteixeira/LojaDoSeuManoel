using LojaDoSeuManoel.Models;

namespace LojaDoSeuManoel.Services;

public class EmbalagemService
{
    private readonly List<Caixa> _caixasDisponiveis = new()
    {
        new Caixa { Nome = "Caixa 1", Altura = 30, Largura = 40, Comprimento = 80 },
        new Caixa { Nome = "Caixa 2", Altura = 80, Largura = 50, Comprimento = 40 },
        new Caixa { Nome = "Caixa 3", Altura = 50, Largura = 80, Comprimento = 60 },
    };

    public List<(Caixa caixa, List<Produto> produtos)> Embalar(List<Produto> produtos)
    {
        var resultado = new List<(Caixa, List<Produto>)>();
        var produtosRestantes = new List<Produto>(produtos);

        while (produtosRestantes.Any())
        {
            bool produtoFoiAlojado = false;

            foreach (var modeloCaixa in _caixasDisponiveis.OrderBy(c => c.Altura * c.Largura * c.Comprimento))
            {
                var volumeMaximoCaixa = modeloCaixa.Altura * modeloCaixa.Largura * modeloCaixa.Comprimento;
                var produtosNaCaixa = new List<Produto>();
                decimal volumeUsado = 0;

                foreach (var produto in produtosRestantes.ToList())
                {
                    var volumeProduto = produto.Altura * produto.Largura * produto.Comprimento;

                    if (produto.Altura <= modeloCaixa.Altura &&
                        produto.Largura <= modeloCaixa.Largura &&
                        produto.Comprimento <= modeloCaixa.Comprimento)
                    {
                        if (volumeProduto <= (volumeMaximoCaixa - volumeUsado))
                        {
                            produtosNaCaixa.Add(produto);
                            volumeUsado += volumeProduto;
                            produtosRestantes.Remove(produto);
                        }
                    }
                }

                if (produtosNaCaixa.Any())
                {
                    resultado.Add((modeloCaixa, produtosNaCaixa));
                    produtoFoiAlojado = true;
                    break;
                }
            }

            if (!produtoFoiAlojado)
            {
                var produtoNaoAcomodado = produtosRestantes.First();
                resultado.Add((null, new List<Produto> { produtoNaoAcomodado }));
                break;
            }
        }

        return resultado;
    }

}
