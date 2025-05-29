using LojaDoSeuManoel.Data;
using LojaDoSeuManoel.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Constrói a connection string dinamicamente
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "SenhaNaoInformada";
var connectionString = $"Server=sqlserver,1433;Database=LojaDoSeuManoel;User Id=sa;Password={dbPassword};TrustServerCertificate=True;";

builder.Services.AddDbContext<EmbalagemDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<EmbalagemService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
        };
    });

builder.Services.AddAuthorization();

// Configura o AuthService para a autenticação
builder.Services.AddSingleton<AuthService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configuração do Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor, insira o token JWT com o prefixo 'Bearer' nas requisições.",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


var app = builder.Build();

// Ativa o Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.DefaultModelsExpandDepth(-1);  // Evita que o Swagger mostre modelos complexos, se não for necessário
});

// Configurações de autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Mapeia os controllers
app.MapControllers();

app.Urls.Add("http://0.0.0.0:80");
app.Run();

