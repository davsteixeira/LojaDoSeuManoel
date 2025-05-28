namespace Embalagem.API.Models;

public class Produto
{
    public string Nome { get; set; } = string.Empty;
    public decimal Altura { get; set; }
    public decimal Largura { get; set; }
    public decimal Comprimento { get; set; }
}
