namespace LojaDoSeuManoel.Dtos;

public class CaixaResponseDto
    {
        public string Caixa_Id { get; set; } = string.Empty;
        public List<string> Produtos { get; set; } = new();
        public string? Observacao { get; set; }
    }
