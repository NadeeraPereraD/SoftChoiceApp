using Microsoft.AspNetCore.Identity;
using SoftChoiceApp.API.Interfaces;
using SoftChoiceApp.API.Models.DTOs.UserManagementDTO;
using SoftChoiceApp.API.Models.Entities;

namespace SoftChoiceApp.API.Services.UserManagement
{
    public class UsersServices : IUsersService
    {
        private readonly IUsersRepository _repo;
        private readonly IPasswordHasher<UsersCreateDto> _passwordHasher;
        public UsersServices(IUsersRepository repo) 
        {
            _repo = repo;
            _passwordHasher = new PasswordHasher<UsersCreateDto>();
        }
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> CreateAsync(UsersCreateDto dto)
        { 
            dto.Password = _passwordHasher.HashPassword(dto, dto.Password);
            return await _repo.CreateAsync(dto); 
        }
        public Task<(IEnumerable<UserWithRolesDto> users, string? ErrorMessage, string? SuccessMessage)> GetAllUsersAsync()
            => _repo.GetAllAsync();
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
    }
}
