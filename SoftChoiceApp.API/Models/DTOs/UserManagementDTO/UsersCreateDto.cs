namespace SoftChoiceApp.API.Models.DTOs.UserManagementDTO
{
    public class UsersCreateDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string NIC { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
    }
}
