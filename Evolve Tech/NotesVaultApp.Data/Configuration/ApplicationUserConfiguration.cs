using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotesVaultApp.Data.Models;

namespace NotesVaultApp.Data.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.
                HasData(
                new ApplicationUser
                {
                    Id = 1,
                    Username = "admin",
                    Email = "stefan08@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "admin")
                },
                new ApplicationUser
                {
                    Id = 2,
                    Username = "user1",
                    Email = "user1@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "user1")
                }
                );
        }
    }
}
