using SoftChoiceApp.API.Interfaces;
using SoftChoiceApp.API.Models.DTOs.UserManagementDTO;
using SoftChoiceApp.API.Models.Entities;

namespace SoftChoiceApp.API.Services.UserManagement
{
    public class UserRolesServices : IUserRolesService
    {
        private readonly IUserRolesRepository _repo;

        public UserRolesServices(IUserRolesRepository repo)
        {
            _repo = repo;
        }

        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> CreateAsync(UserRolesCreateDto dto)
            => await _repo.CreateAsync(dto);
        public Task<(IEnumerable<UserRole> userRoles, string? ErrorMessage, string? SuccessMessage)> GetAllUserRolesAsync()
            => _repo.GetAllAsync();
        //public async Task<UserRolesResponseDto> GetUserRolesAsync(UserRolesRequestDto request);
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> UpdateAsyncByID(UserRolesUpdateDto dto)
            => await _repo.UpdateByKeyAsync(dto);
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> SoftDeleteAsyncByID(UserRolesSoftDeleteDto dto)
            => await _repo.SoftDeleteByKeyAsync(dto);
        public async Task<(IEnumerable<UserRole> userRoles, string? ErrorMessage, string? SuccessMessage)> GetAllInactiveUserRolesAsync()
            => await _repo.GetAllInactiveAsync();
    }
}
