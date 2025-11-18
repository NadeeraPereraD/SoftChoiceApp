namespace SoftChoiceApp.API.Models.DTOs.UserManagementDTO
{
    public class UsersSoftDeleteDto
    {
        public int Id { get; set; }
        public string UpdatedBy { get; set; } = null!;
    }
}
