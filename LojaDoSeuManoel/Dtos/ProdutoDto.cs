﻿namespace LojaDoSeuManoel.Dtos;
using System.ComponentModel.DataAnnotations;

public class ProdutoDto
{
    [Required(ErrorMessage = "O ID do produto é obrigatório.")]
    public string Produto_Id { get; set; } = string.Empty;
    
    public DimensaoDto Dimensoes { get; set; }
}

