namespace SoftChoiceApp.API.Models.DTOs.UserManagementDTO
{
    public class UserRolesUpdateDto
    {
        public int Id { get; set; }
        public string Role { get; set; } = null!;
        public string UpdatedBy { get; set; } = null!;
    }
}
