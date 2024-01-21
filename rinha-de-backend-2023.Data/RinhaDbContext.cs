using Microsoft.EntityFrameworkCore;
using rinha_de_backend_2023.Data.Models;

namespace rinha_de_backend_2023.Data;

public class RinhaDbContext : DbContext
{
    public DbSet<Pessoa> Pessoas => Set<Pessoa>();
    
    public RinhaDbContext(DbContextOptions<RinhaDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pessoa>()
            .HasAlternateKey(p => p.Apelido);
    } 
}