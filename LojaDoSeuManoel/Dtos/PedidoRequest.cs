namespace LojaDoSeuManoel.Dtos;

public class PedidoRequest
{
    public int Id { get; set; }
    public List<ProdutoDto> Produtos { get; set; } = new();
}

