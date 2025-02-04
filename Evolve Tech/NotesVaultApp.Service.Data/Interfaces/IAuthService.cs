﻿namespace NotesVaultApp.Service.Data.Interfaces
{
    public interface IAuthService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string storedHash);
    }
}
