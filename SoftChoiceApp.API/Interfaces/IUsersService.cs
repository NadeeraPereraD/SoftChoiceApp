using SoftChoiceApp.API.Models.DTOs.UserManagementDTO;
using SoftChoiceApp.API.Models.Entities;

namespace SoftChoiceApp.API.Interfaces
{
    public interface IUsersService
    {
        Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> CreateAsync(UsersCreateDto dto);
        Task<(IEnumerable<User> users, string? ErrorMessage, string? SuccessMessage)> GetAllUserRolesAsync();
        Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> UpdateAsyncByID(UsersUpdateDto dto);
        Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> SoftDeleteAsyncByID(UsersSoftDeleteDto dto);
        Task<(IEnumerable<User> users, string? ErrorMessage, string? SuccessMessage)> GetAllInactiveUserRolesAsync();
    }
}
