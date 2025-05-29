namespace LojaDoSeuManoel.Dtos;

public class PedidoRequestDto
{
    public int Pedido_Id { get; set; }
    public List<ProdutoDto> Produtos { get; set; } = new();
}

