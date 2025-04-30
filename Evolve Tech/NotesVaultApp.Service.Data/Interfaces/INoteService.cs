using NotesVaultApp.Data.Models;

namespace NotesVaultApp.Service.Data.Interfaces
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetAllNotesAsync();
        Task<Note> GetNoteByIdAsync(int id);
        Task<Note> CreateNoteAsync(Note note);
        Task<bool> UpdateNoteAsync(int id, Note note);
        Task<bool> DeleteNoteAsync(int id);
    }
}
