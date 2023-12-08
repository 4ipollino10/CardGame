using CardGame.AncientGods.Core.GameDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardGame.AncientGods.Infrastructure.GameDomain.EntityFramework.Configuration;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder
            .ToTable(nameof(Game));

        builder
            .HasKey(x => x.Id);
    }
}