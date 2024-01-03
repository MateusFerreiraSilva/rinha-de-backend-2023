using Microsoft.EntityFrameworkCore;
using rinha_de_backend_2023.Data.Models;

namespace rinha_de_backend_2023.Data;

public class RinhaDbContext : DbContext
{
    public DbSet<Pessoa> Pessoas => Set<Pessoa>();
    public DbSet<Technology> Technologies => Set<Technology>();

    public RinhaDbContext(DbContextOptions<RinhaDbContext> options) : base(options)
    {
    }
}