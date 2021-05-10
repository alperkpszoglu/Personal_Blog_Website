using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace BlogMvcApp.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() {Name = "admin"};
                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "user"}; ;
                manager.Create(role);
            }

            if (!context.Users.Any(i => i.UserName == "alper"))
            {
                var store = new UserStore<IdentityUser>(context);
                var manager = new UserManager<IdentityUser>(store);
                var user = new IdentityUser() { UserName="alper",Email="alper@gmail.com"};

                manager.Create(user, "alper123");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }

            if (!context.Users.Any(i => i.UserName == "ali"))
            {
                var store = new UserStore<IdentityUser>(context);
                var manager = new UserManager<IdentityUser>(store);
                var user = new IdentityUser() { UserName="ali",Email="ali@gmail.com"};

                manager.Create(user, "ali123");
                manager.AddToRole(user.Id, "user");
            }
            


            base.Seed(context);
        }
    }
}