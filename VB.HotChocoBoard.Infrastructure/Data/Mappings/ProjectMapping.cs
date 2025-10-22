using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VB.HotChocoBoard.Domain.Projects.Entities;

namespace VB.HotChocoBoard.Infrastructure.Data.Mappings;

public sealed class ProjectMapping : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasMany(proj => proj.Sprints)
            .WithOne(sprint => sprint.Project)
            .HasForeignKey(sprint => sprint.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}