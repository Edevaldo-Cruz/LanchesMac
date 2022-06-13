using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }


        //Mapeamento de tabelas
        public DbSet<Categoria> Categorias { get; set; }
        public  DbSet<Lanche> Lanches { get; set; }
    }
}
