using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesVaultApp.Data;
using NotesVaultApp.Data.Models;
using NotesVaultApp.DTOs;
using NotesVaultApp.Service.Data.Interfaces;

namespace NotesVaultApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly NotesVaultDbContext _context;
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(NotesVaultDbContext context, IAuthService authService, ITokenService tokenService)
        {
            _context = context;
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (_context.Users.Any(u => u.Email == dto.Email))
                return BadRequest("Email already in use!");

            var user = new ApplicationUser
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = _authService.HashPassword(dto.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User registered!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !_authService.VerifyPassword(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid credentials!");

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
