using SoftChoiceApp.API.Models.DTOs.UserManagementDTO;
using SoftChoiceApp.API.Models.Entities;

namespace SoftChoiceApp.API.Interfaces
{
    public interface IUserRolesRepository
    {
        Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> CreateAsync(UserRolesCreateDto dto);
        Task<(IEnumerable<UserRole> userRoles, string? ErrorMessage, string? SuccessMessage)> GetAllAsync();
        //Task<(UserRole? Entity, string? ErrorMessage, string? SuccessMessage)> GetByKeyAsync(string Role);
        Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> UpdateByKeyAsync(UserRolesUpdateDto dto);
        Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> SoftDeleteByKeyAsync(UserRolesSoftDeleteDto dto);
        Task<(IEnumerable<UserRole> userRoles, string? ErrorMessage, string? SuccessMessage)> GetAllInactiveAsync();

    }
}
