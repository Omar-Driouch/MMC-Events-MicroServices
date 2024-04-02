
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Domain.Entities
{
    public class ApplicationUser
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool isEmailVerified { get; set; }=false;
        public DateTime? VerifiedAt { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }


    }
}
