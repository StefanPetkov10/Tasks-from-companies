namespace NotesVaultApp.Data.Models
{
    public class ApplicationUser
    {
        public ApplicationUser()
        {
            Notes = new List<Note>();
        }

        public int Id { get; set; } //This will be better as a GUID(but for now is int)
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public List<Note> Notes { get; set; }
    }
}
