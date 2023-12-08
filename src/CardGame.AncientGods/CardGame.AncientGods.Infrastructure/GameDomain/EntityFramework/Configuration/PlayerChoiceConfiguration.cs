using CardGame.AncientGods.Core.GameDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardGame.AncientGods.Infrastructure.GameDomain.EntityFramework.Configuration;

public class PlayerChoiceConfiguration : IEntityTypeConfiguration<PlayerChoice>
{
    public void Configure(EntityTypeBuilder<PlayerChoice> builder)
    {
        builder
            .ToTable(nameof(PlayerChoice));

        builder
            .HasKey(x => x.Id);
    }
}