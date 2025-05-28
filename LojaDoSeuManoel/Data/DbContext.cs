// Em: Embalagem.API/Data/EmbalagemDbContext.cs
using Microsoft.EntityFrameworkCore;
using Embalagem.API.Models;
using System.Collections.Generic;

namespace Embalagem.API.Data
{
    public class EmbalagemDbContext : DbContext
    {
        public EmbalagemDbContext(DbContextOptions<EmbalagemDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<Produto> Produtos => Set<Produto>();
    }
}

