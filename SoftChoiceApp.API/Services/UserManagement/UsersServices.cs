using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SoftChoiceApp.API.Interfaces;
using SoftChoiceApp.API.Models.DTOs.UserManagementDTO;
using SoftChoiceApp.API.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SoftChoiceApp.API.Services.UserManagement
{
    public class UsersServices : IUsersService
    {
        private readonly IUsersRepository _repo;
        private readonly IPasswordHasher<object> _passwordHasher;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UsersServices(IUsersRepository repo, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            _passwordHasher = new PasswordHasher<object>();
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> CreateAsync(UsersCreateDto dto)
        { 
            dto.Password = _passwordHasher.HashPassword(dto, dto.Password);
            return await _repo.CreateAsync(dto); 
        }
        public async Task<(IEnumerable<UserWithRolesDto> users, string? ErrorMessage, string? SuccessMessage)> GetAllUsersAsync()
        {
            var result = await _repo.GetAllAsync();
            var userRoles = _httpContextAccessor.HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            bool isSuperAdmin = userRoles.Contains("1"); 
            bool isAdmin = userRoles.Contains("2");      

            if (isSuperAdmin)
                return result;

            if (isAdmin)
            {
                var filteredUsers = result.users
                    .Where(u => !u.Roles.Contains("SuperAdmin") && !u.Roles.Contains("1"))
                    .ToList();

                return (filteredUsers, result.ErrorMessage, result.SuccessMessage);
            }

            return (new List<UserWithRolesDto>(), "Not authorized", null);
        }
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> UpdateAsyncByID(UsersUpdateDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                var passwordHasher = new PasswordHasher<UsersUpdateDto>();
                dto.Password = passwordHasher.HashPassword(dto, dto.Password);
            }
            return await _repo.UpdateByKeyAsync(dto); 
        }
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> SoftDeleteAsyncByID(UsersSoftDeleteDto dto)
            => await _repo.SoftDeleteByKeyAsync(dto);
        public async Task<(IEnumerable<UserWithRolesDto> users, string? ErrorMessage, string? SuccessMessage)> GetAllInactiveUserRolesAsync()
            => await _repo.GetAllInactiveAsync();

        public async Task<(bool IsSuccess, string? ErrorMessage, string? Token)> LoginAsync(LoginRequestDto dto)
        {
            var user = await _repo.GetUserByEmailUNameAsync(dto.Login);

            if (user == null)
                return (false, "Invalid email or password", null);

            var verificationResult = _passwordHasher.VerifyHashedPassword(dto, user.Password, dto.Password);

            if (verificationResult == PasswordVerificationResult.Failed)
                return (false, "Invalid email or password", null);

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtKey = _configuration["Jwt:Key"];
            if (string.IsNullOrWhiteSpace(jwtKey))
                throw new InvalidOperationException("JWT Key is missing in configuration.");

            var key = Encoding.UTF8.GetBytes(jwtKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserName", user.UserName) // custom claim for username
            };

            foreach (var roleId in user.RoleIds)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleId.ToString())); // custom claim
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1), // 1 hour token
                SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return (true, null, tokenString);
        }

    }
}
