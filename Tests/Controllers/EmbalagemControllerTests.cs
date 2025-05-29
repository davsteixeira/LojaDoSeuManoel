using System.Collections.Generic;
using System.Linq;
using LojaDoSeuManoel.Controllers;
using LojaDoSeuManoel.Dtos;
using LojaDoSeuManoel.Models;
using LojaDoSeuManoel.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LojaDoSeuManoel.Tests.Controllers
{
    public class EmbalagemControllerTests
    {
        private readonly Mock<EmbalagemService> _mockService;
        private readonly EmbalagemController _controller;

        public EmbalagemControllerTests()
        {
            _mockService = new Mock<EmbalagemService>();
            _controller = new EmbalagemController(_mockService.Object);
        }

        [Fact]
        public void Post_QuandoModelStateInvalido_RetornaBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Pedido", "Erro na validação");

            var requisicao = new RequisicaoPedidosDto
            {
                Pedidos = new List<PedidoRequestDto>()
            };

            // Act
            var result = _controller.Post(requisicao);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.NotNull(badRequestResult.Value);
        }
    }
}
