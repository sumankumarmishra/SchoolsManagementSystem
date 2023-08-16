﻿using Microsoft.AspNetCore.Identity;

namespace Models.Entities.Identity;

public class User : IdentityUser<int>
{
    public string Name { get; set; } = string.Empty;
    public string PlainPassword { get; set; } = string.Empty;
    public string ProfilePicturePath { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty;
    public Guid RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryDate { get; set; }
    public virtual ICollection<UserClass> UserClasses { get; set; } = new HashSet<UserClass>();
    public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    public virtual ICollection<ActivityInstanceUser> ActivityInstanceUsers { get; set; } = new HashSet<ActivityInstanceUser>();
}
