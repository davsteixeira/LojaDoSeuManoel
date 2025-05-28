using LojaDoSeuManoel.Data;
using LojaDoSeuManoel.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Constr�i a connection string dinamicamente
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "SenhaNaoInformada";
var connectionString = $"Server=sqlserver,1433;Database=LojaDoSeuManoel;User Id=sa;Password={dbPassword};TrustServerCertificate=True;";

builder.Services.AddDbContext<EmbalagemDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<EmbalagemService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Urls.Add("http://0.0.0.0:80");
app.Run();
