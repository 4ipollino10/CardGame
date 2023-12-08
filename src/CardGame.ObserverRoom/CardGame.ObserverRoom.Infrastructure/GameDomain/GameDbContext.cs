using System.Reflection;
using CardGame.ObserverRoom.Core.GameDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardGame.ObserverRoom.Infrastructure.GameDomain;

public sealed class GameDbContext : DbContext
{
    public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    public DbSet<Game> Games { get; set; }
    public DbSet<ActivitySession> ActivitySessions { get; set; }
}