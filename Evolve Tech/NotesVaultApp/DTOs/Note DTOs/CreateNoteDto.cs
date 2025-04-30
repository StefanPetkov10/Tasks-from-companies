using System.ComponentModel.DataAnnotations;

namespace NotesVaultApp.DTOs.Note_DTOs
{
    public class CreateNoteDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title must be between 3 and 100 characters.", MinimumLength = 3)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; } = null!;

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; } = null!;
    }
}
