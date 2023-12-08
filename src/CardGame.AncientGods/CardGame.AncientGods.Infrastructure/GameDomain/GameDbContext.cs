using System.Reflection;
using CardGame.AncientGods.Core.GameDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardGame.AncientGods.Infrastructure.GameDomain;

public class GameDbContext : DbContext
{
    public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<PlayerChoice> PlayerChoice { get; set; }
    public DbSet<Game> Game { get; set; }
}