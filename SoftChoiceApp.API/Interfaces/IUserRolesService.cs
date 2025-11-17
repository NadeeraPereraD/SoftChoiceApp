using SoftChoiceApp.API.Models.DTOs.UserManagementDTO;
using SoftChoiceApp.API.Models.Entities;

namespace SoftChoiceApp.API.Interfaces
{
    public interface IUserRolesService
    {
        Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> CreateAsync(UserRolesCreateDto dto);
        Task<(IEnumerable<UserRole> userRoles, string? ErrorMessage, string? SuccessMessage)> GetAllUserRolesAsync();
        Task<UserRolesResponseDto> GetUserRolesAsync(UserRolesRequestDto request);
        Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> UpdateAsyncByID(UserRolesUpdateDto dto);
        Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> SoftDeleteAsyncByID(UserRolesSoftDeleteDto dto);
        Task<(IEnumerable<UserRole> userRoles, string? ErrorMessage, string? SuccessMessage)> GetAllInactiveUserRolesAsync();
    }
}
