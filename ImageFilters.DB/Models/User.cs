using Microsoft.AspNetCore.Identity;


namespace ImageFilters.DB.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
