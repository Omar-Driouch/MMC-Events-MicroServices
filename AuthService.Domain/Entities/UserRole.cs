using System.ComponentModel.DataAnnotations;

namespace AuthService.Domain.Entities
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser applicationUser { get; set; }

        public int RoleId { get; set; }
        public Role role { get; set; }
    }

}
