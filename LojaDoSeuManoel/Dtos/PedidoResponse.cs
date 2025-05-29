namespace LojaDoSeuManoel.Dtos;

public class PedidoResponseDto
{
    public int Pedido_Id { get; set; }
    public List<CaixaResponseDto> Caixas { get; set; } = new();
}
