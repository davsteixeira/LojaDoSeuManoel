namespace Embalagem.API.Dtos;

public class PedidoResponse
{
    public int PedidoId { get; set; }
    public List<CaixaResponse> Caixas { get; set; } = new();
}
