namespace SoftChoiceApp.API.Models.DTOs.UserManagementDTO
{
    public class UserWithRoleIdsDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public List<int> RoleIds { get; set; } = new();
    }
}
