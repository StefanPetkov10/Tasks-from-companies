using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotesVaultApp.Data.Models;

namespace NotesVaultApp.Data.Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(n => n.Content)
                .IsRequired();

            builder
                .HasOne(n => n.Category)
                .WithMany(c => c.Notes)
                .HasForeignKey(n => n.CategoryId);

            builder
                .HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.UserId);

            builder
                .HasData
                (
                    new Note
                    {
                        Id = 1,
                        Title = "First Note",
                        Content = "This is the content of the first note",
                        CreatedAt = "04-02-2025",
                        UpdatedAt = "05-02-2025",
                        CategoryId = 1,
                        UserId = 1
                    },
                    new Note
                    {
                        Id = 2,
                        Title = "Second Note",
                        Content = "This is the content of the second note",
                        CreatedAt = "05-02-2025",
                        CategoryId = 2,
                        UserId = 1
                    },
                    new Note
                    {
                        Id = 3,
                        Title = "Third Note",
                        Content = "This is the content of the third note",
                        CreatedAt = "06-02-2025",
                        CategoryId = 3,
                        UserId = 1
                    }
                );
        }
    }
}
