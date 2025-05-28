namespace Embalagem.API.Dtos;

public class CaixaResponse
{
    public string Nome { get; set; } = string.Empty;
    public List<ProdutoDto> Produtos { get; set; } = new();
}
