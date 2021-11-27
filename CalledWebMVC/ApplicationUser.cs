using System;
using Microsoft.AspNetCore.Identity;

namespace CalledWebMVC
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string DisplayName { get; set; }
    }
}