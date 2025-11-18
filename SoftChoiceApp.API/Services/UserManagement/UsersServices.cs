using SoftChoiceApp.API.Interfaces;
using SoftChoiceApp.API.Models.DTOs.UserManagementDTO;
using SoftChoiceApp.API.Models.Entities;

namespace SoftChoiceApp.API.Services.UserManagement
{
    public class UsersServices : IUsersService
    {
        private readonly IUsersRepository _repo;
        public UsersServices(IUsersRepository repo) 
        {
            _repo = repo; 
        }
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> CreateAsync(UsersCreateDto dto)
            => await _repo.CreateAsync(dto);
        public Task<(IEnumerable<User> users, string? ErrorMessage, string? SuccessMessage)> GetAllUsersAsync()
            => _repo.GetAllAsync();
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> UpdateAsyncByID(UsersUpdateDto dto)
            => await _repo.UpdateByKeyAsync(dto);
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> SoftDeleteAsyncByID(UsersSoftDeleteDto dto)
            => await _repo.SoftDeleteByKeyAsync(dto);
        public async Task<(IEnumerable<User> users, string? ErrorMessage, string? SuccessMessage)> GetAllInactiveUserRolesAsync()
            => await _repo.GetAllInactiveAsync();
    }
}
