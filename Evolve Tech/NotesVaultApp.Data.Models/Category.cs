using NotesVaultApp.Data.Models.Enums;

namespace NotesVaultApp.Data.Models
{
    public class Category
    {
        public Category()
        {
            Notes = new List<Note>();
        }

        public int Id { get; set; }
        public Categories Name { get; set; }
        public List<Note> Notes { get; set; }
    }
}
