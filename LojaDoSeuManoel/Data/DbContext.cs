using Microsoft.EntityFrameworkCore;
using LojaDoSeuManoel.Models;

namespace LojaDoSeuManoel.Data
{
    public class EmbalagemDbContext : DbContext
    {
        public EmbalagemDbContext(DbContextOptions<EmbalagemDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<Produto> Produtos => Set<Produto>();
    }
}

