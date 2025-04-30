using NotesVaultApp.Data.Models;

namespace NotesVaultApp.Service.Data.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(ApplicationUser user);
    }
}
