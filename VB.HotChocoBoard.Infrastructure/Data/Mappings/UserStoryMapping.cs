using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VB.HotChocoBoard.Domain.UserStories.Entities;

namespace VB.HotChocoBoard.Infrastructure.Data.Mappings;

public sealed class UserStoryMapping : IEntityTypeConfiguration<UserStory>
{
    public void Configure(EntityTypeBuilder<UserStory> builder)
    {
        builder.HasKey(us => us.Id);
        
        builder
            .Property(us => us.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(us => us.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(us => us.Description)
            .HasMaxLength(3000)
            .IsRequired();
        
        builder
            .Property(us => us.SprintId)
            .IsRequired(false);
        
        builder
            .Property(us => us.ProjectId)
            .IsRequired();
        
        builder
            .Property(us => us.Priority)
            .HasConversion<string>()
            .IsRequired();
        
        builder
            .HasMany(us => us.Tasks)
            .WithOne(tt => tt.UserStory)
            .HasForeignKey(tt => tt.UserStoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}