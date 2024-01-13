using Microsoft.AspNetCore.Identity;

namespace ccse_cw1.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string PassportNumber { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
