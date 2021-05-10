using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    public class RoleEditModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<IdentityUser> Users { get; set; }
        public IEnumerable<IdentityUser> NonUsers { get; set; }
    }
}