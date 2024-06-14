using Microsoft.AspNetCore.Identity;

namespace FrontEnd.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public bool IsAdmin { get; set; }

    public bool IsAttendee { get; set; }
}

