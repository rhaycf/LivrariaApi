using LivrariaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrariaApi.Data
{
    public class LivroContext : DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> options) : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
    }
}

