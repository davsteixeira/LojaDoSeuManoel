namespace LojaDoSeuManoel.Dtos;
using System.ComponentModel.DataAnnotations;

public class PedidoRequestDto
{   
    [Required(ErrorMessage = "O ID do pedido é obrigatório.")]
    public int Pedido_Id { get; set; }

    [Required(ErrorMessage = "A lista de produtos é obrigatória.")]
    [MinLength(1, ErrorMessage = "Pelo menos um produto deve ser enviado.")]
    public List<ProdutoDto> Produtos { get; set; } = new();
}

