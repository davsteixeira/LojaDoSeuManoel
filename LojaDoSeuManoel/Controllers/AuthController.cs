using LojaDoSeuManoel.Dtos;
using LojaDoSeuManoel.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LojaDoSeuManoel.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto dto)
    {
        if (_authService.ValidarCredenciais(dto.Email, dto.Senha))
        {
            var token = _authService.GerarToken(dto.Email);
            return Ok(new { token });
        }

        return Unauthorized(new { mensagem = "Credenciais inválidas" });
    }
}
