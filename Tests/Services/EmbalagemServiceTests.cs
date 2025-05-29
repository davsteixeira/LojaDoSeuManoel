using LojaDoSeuManoel.Services;
using LojaDoSeuManoel.Models;
using FluentAssertions;

namespace Tests.Services
{
    public class EmbalagemServiceTests
    {
        private readonly EmbalagemService _service;

        public EmbalagemServiceTests()
        {
            _service = new EmbalagemService();
        }

        [Fact]
        public void Deve_Colocar_Produto_Pequeno_Na_Menor_Caixa()
        {
            var produtos = new List<Produto>
            {
                new Produto
                {
                    Produto_Id = "Bola",
                    Nome = "Bola",
                    Altura = 10,
                    Largura = 10,
                    Comprimento = 10
                }
            };

            var resultado = _service.Embalar(produtos);

            resultado.Should().HaveCount(1);
            resultado[0].caixa.Should().NotBeNull();
            resultado[0].caixa.Nome.Should().Be("Caixa 1");
            resultado[0].produtos.Should().ContainSingle(p => p.Nome == "Bola");
        }

        [Fact]
        public void Deve_Colocar_Produtos_Grandes_Em_Caixas_Maiores()
        {
            var produtos = new List<Produto>
            {
                new Produto { Produto_Id = "Cadeira", Nome = "Cadeira", Altura = 50, Largura = 50, Comprimento = 50 }
            };

            var resultado = _service.Embalar(produtos);

            resultado.Should().HaveCount(1);
            resultado[0].caixa.Should().NotBeNull();
            resultado[0].caixa.Nome.Should().Match<string>(nome => nome == "Caixa 2" || nome == "Caixa 3");
        }

        [Fact]
        public void Deve_Retornar_Produto_Que_Nao_Cabe_Em_Nenhuma_Caixa()
        {
            var produtos = new List<Produto>
            {
                new Produto { Produto_Id = "Cadeira Gamer", Nome = "Cadeira Gamer", Altura = 100, Largura = 100, Comprimento = 100 }
            };

            var resultado = _service.Embalar(produtos);

            resultado.Should().HaveCount(1);
            resultado[0].caixa.Should().BeNull();
            resultado[0].produtos.Should().ContainSingle(p => p.Nome == "Cadeira Gamer");
        }

        [Fact]
        public void Deve_Distribuir_Produtos_Em_Multiplas_Caixas_Quando_Necessario()
        {
            var produtos = new List<Produto>
    {
        new Produto { Produto_Id = "PS4", Nome = "PS4", Altura = 30, Largura = 30, Comprimento = 30 },
        new Produto { Produto_Id = "Xbox", Nome = "Xbox", Altura = 30, Largura = 30, Comprimento = 30 },
        new Produto { Produto_Id = "Nintendo", Nome = "Nintendo", Altura = 30, Largura = 30, Comprimento = 30 }
    };

            var resultado = _service.Embalar(produtos);


            resultado.Should().NotBeNull();
            resultado.SelectMany(r => r.produtos).Should().HaveCount(3);
            resultado.Count.Should().BeGreaterThan(0);

        }

    }
}
