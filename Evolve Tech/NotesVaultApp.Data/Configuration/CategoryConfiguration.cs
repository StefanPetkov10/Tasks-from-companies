using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotesVaultApp.Data.Models;
using NotesVaultApp.Data.Models.Enums;

namespace NotesVaultApp.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(c => c.Notes)
                .WithOne(n => n.Category)
                .HasForeignKey(n => n.CategoryId);

            builder
                .HasData(
                    new Category
                    {
                        Id = 1,
                        Name = Categories.Personal
                    },
                    new Category
                    {
                        Id = 2,
                        Name = Categories.Work
                    },
                    new Category
                    {
                        Id = 3,
                        Name = Categories.General
                    }
                );
        }
    }
}
