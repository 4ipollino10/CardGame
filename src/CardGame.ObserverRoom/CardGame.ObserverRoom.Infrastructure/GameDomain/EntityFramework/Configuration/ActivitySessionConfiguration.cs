using CardGame.ObserverRoom.Core.GameDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardGame.ObserverRoom.Infrastructure.GameDomain.EntityFramework.Configuration;

public class ActivitySessionConfiguration : IEntityTypeConfiguration<ActivitySession>
{
    public void Configure(EntityTypeBuilder<ActivitySession> builder)
    {
        builder
            .ToTable(nameof(ActivitySession));

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasMany(x => x.Games)
            .WithOne()
            .HasForeignKey(x => x.ActivitySessionId)
            .IsRequired();
    }
}