using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VB.HotChocoBoard.Domain.Sprints.Entities;

namespace VB.HotChocoBoard.Infrastructure.Data.Mappings;

public sealed class SprintMapping : IEntityTypeConfiguration<Sprint>
{
    public void Configure(EntityTypeBuilder<Sprint> builder)
    {
        builder.HasKey(sprint => sprint.Id);
        
        builder
            .Property(sprint => sprint.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(sprint => sprint.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(sprint => sprint.StartDate)
            .IsRequired();
        
        builder
            .Property(sprint => sprint.EndDate)
            .IsRequired();
        
        builder
            .HasMany(sprint => sprint.Stories)
            .WithOne(us => us.Sprint)
            .HasForeignKey(us => us.SprintId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}