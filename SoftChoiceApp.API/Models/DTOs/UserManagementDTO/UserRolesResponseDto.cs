namespace SoftChoiceApp.API.Models.DTOs.UserManagementDTO
{
    public class UserRolesResponseDto
    {
        public UserRolesDto? UserRolesDto { get; set; }
        public string? ErrorMessage { get; set; }
        public string? SuccessMessage { get; set; }
    }
}
