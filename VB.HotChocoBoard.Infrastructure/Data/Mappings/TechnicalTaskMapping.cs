using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VB.HotChocoBoard.Domain.Tasks.Entities;

namespace VB.HotChocoBoard.Infrastructure.Data.Mappings;

public sealed class TechnicalTaskMapping : IEntityTypeConfiguration<TechnicalTask>
{
    public void Configure(EntityTypeBuilder<TechnicalTask> builder)
    {
        builder.HasKey(tt => tt.Id);
        
        builder
            .Property(tt => tt.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(tt => tt.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(tt => tt.Description)
            .HasMaxLength(3000)
            .IsRequired();
        
        builder
            .Property(tt => tt.Status)
            .HasConversion<string>()
            .IsRequired();
        
        builder
            .Property(tt => tt.UserStoryId)
            .IsRequired();
    }
}