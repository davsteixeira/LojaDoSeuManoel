using System;

namespace Embalagem.API.Models;

public class Produto
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public int Altura { get; set; }
    public int Largura { get; set; }
    public int Comprimento { get; set; }
}