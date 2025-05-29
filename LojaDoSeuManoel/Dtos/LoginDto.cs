using System;
using System.ComponentModel.DataAnnotations;

namespace LojaDoSeuManoel.Dtos;

public class LoginDto
{
    [Required(ErrorMessage = "O campo 'Email' é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo 'Email' deve ser um endereço de email válido.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "O campo 'Senha' é obrigatório.")]
    [MinLength(4, ErrorMessage = "A 'Senha' deve ter pelo menos 4 caracteres.")]
    public string Senha { get; set; }
}

