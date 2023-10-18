using Microsoft.AspNetCore.Identity;

namespace TopTrump.Areas.Data
{
    public class AppUser : IdentityUser
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
