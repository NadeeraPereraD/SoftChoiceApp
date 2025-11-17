using System.ComponentModel.DataAnnotations;

namespace SoftChoiceApp.API.Models.DTOs.UserManagementDTO
{
    public class UserRolesDto
    {
        public int Id { get; set; }
        public string Role { get; set; } = null!;
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set;} = null!;
        public DateTime UpdatedDate { get; set;}

    }
}
