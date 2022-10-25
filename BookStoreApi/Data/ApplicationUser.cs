using Microsoft.AspNetCore.Identity;

namespace BookStoreApi.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}