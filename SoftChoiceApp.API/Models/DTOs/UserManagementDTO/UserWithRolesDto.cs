namespace SoftChoiceApp.API.Models.DTOs.UserManagementDTO
{
    public class UserWithRolesDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string NIC { get; set; } = null!;
        public string Address { get; set; } = null!;
        public List<string> Roles { get; set; } = new();
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = null!;
        public DateTime UpdatedDate { get; set; }


    }
}
