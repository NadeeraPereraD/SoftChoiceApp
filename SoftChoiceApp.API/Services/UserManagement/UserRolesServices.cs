using SoftChoiceApp.API.Interfaces;
using SoftChoiceApp.API.Models.DTOs.UserManagementDTO;
using SoftChoiceApp.API.Models.Entities;
using System.Security.Claims;

namespace SoftChoiceApp.API.Services.UserManagement
{
    public class UserRolesServices : IUserRolesService
    {
        private readonly IUserRolesRepository _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRolesServices(IUserRolesRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> CreateAsync(UserRolesCreateDto dto)
            => await _repo.CreateAsync(dto);
        public async Task<(IEnumerable<UserRole> userRoles, string? ErrorMessage, string? SuccessMessage)> GetAllUserRolesAsync()
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
                var filteredUsers = result.userRoles
                    .Where(u => !u.Role.Contains("SuperAdmin") && !u.Role.Contains("1"))
                    .ToList();

                return (filteredUsers, result.ErrorMessage, result.SuccessMessage);
            }
            return (new List<UserRole>(), "Not authorized", null);
        }
        //public async Task<UserRolesResponseDto> GetUserRolesAsync(UserRolesRequestDto request);
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> UpdateAsyncByID(UserRolesUpdateDto dto)
            => await _repo.UpdateByKeyAsync(dto);
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> SoftDeleteAsyncByID(UserRolesSoftDeleteDto dto)
            => await _repo.SoftDeleteByKeyAsync(dto);
        public async Task<(IEnumerable<UserRole> userRoles, string? ErrorMessage, string? SuccessMessage)> GetAllInactiveUserRolesAsync()
            => await _repo.GetAllInactiveAsync();
    }
}
