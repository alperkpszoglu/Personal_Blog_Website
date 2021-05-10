using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //roles
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);

                var role = new IdentityRole("admin");
                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);

                var role = new IdentityRole("user");
                manager.Create(role);
            }
            //users
            if (!context.Users.Any(i => i.UserName == "Alper"))
            {
                var store = new UserStore<IdentityUser>(context);
                var manager = new UserManager<IdentityUser>(store);

                var user = new IdentityUser()
                {
                    UserName = "Alper",
                    Email = "alper@gmail.com"
                };
                manager.Create(user, "Alper123");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }
           

            if (!context.Users.Any(i => i.UserName == "ali"))
            {
                var store = new UserStore<IdentityUser>(context);
                var manager = new UserManager<IdentityUser>(store);

                var user = new IdentityUser()
                {
                    UserName = "ali",
                    Email = "ali@gmail.com"
                };
                manager.Create(user, "Ali123");
                manager.AddToRole(user.Id, "user");
            }

            base.Seed(context);
        }
    }
}