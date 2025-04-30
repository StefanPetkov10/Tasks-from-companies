namespace NotesVaultApp.DTOs
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string CreatedAt { get; set; } = null!;
        public string? UpdatedAt { get; set; }
        public string Category { get; set; } = null!;
        public string User { get; set; } = null!;
    }
}
