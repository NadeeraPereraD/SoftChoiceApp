using SoftChoiceApp.API.Models.DTOs.UserManagementDTO;
using SoftChoiceApp.API.Models.Entities;

namespace SoftChoiceApp.API.Interfaces
{
    public interface IUsersRepository
    {
        Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> CreateAsync(UsersCreateDto dto);
        Task<(IEnumerable<UserWithRolesDto> users, string? ErrorMessage, string? SuccessMessage)> GetAllAsync();
        Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> UpdateByKeyAsync(UsersUpdateDto dto);
        Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> SoftDeleteByKeyAsync(UsersSoftDeleteDto dto);
        Task<(IEnumerable<UserWithRolesDto> users, string? ErrorMessage, string? SuccessMessage)> GetAllInactiveAsync();
        Task<UserWithRoleIdsDto?> GetUserByEmailUNameAsync(string login);
    }
}
