using System.ComponentModel.DataAnnotations;

namespace LojaDoSeuManoel.Dtos
{
    public class RequisicaoPedidosDto
    {
        [Required(ErrorMessage = "A lista de pedidos é obrigatória.")]
        [MinLength(1, ErrorMessage = "Pelo menos um pedido deve ser enviado.")]
        public List<PedidoRequestDto> Pedidos { get; set; } = new();
    }
}
