using System;
using Microsoft.AspNetCore.Identity;

namespace QuickServe.Domain.Roles.Entities
{
    public class Role :  IdentityRole<Guid>
    {
        public Role(string name) : base(name)
        {
        }
    }
}