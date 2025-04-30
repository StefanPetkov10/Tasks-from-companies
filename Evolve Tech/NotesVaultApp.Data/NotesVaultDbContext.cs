using Microsoft.EntityFrameworkCore;
using NotesVaultApp.Data.Models;

namespace NotesVaultApp.Data
{
    public class NotesVaultDbContext : DbContext
    {
        public NotesVaultDbContext(DbContextOptions<NotesVaultDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configuration.ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.NoteConfiguration());
        }
    }
}
