namespace MVCResumeWebsite.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCResumeWebsite.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCResumeWebsite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVCResumeWebsite.Models.ApplicationDbContext";
        }

        protected override void Seed(MVCResumeWebsite.Models.ApplicationDbContext context)
        {
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
                rm.Create(new IdentityRole { Name = "Admin" });

            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var Me = context.Users.FirstOrDefault(u => u.Email == "steven@fleetinginfinity.com");

            if (Me == null)
                um.Create(new ApplicationUser
                {
                    UserName = "steven@fleetinginfinity.com",
                    Email = "steven@fleetinginfinity.com",
                    FirstName = "Steven",
                    LastName = "Potts"
                }, "Abc123!");

            var user = um.FindByEmail("steven@fleetinginfinity.com");
            if (!um.IsInRole(user.Id, "Admin"))
                um.AddToRole(user.Id, "Admin");
        }
    }
}
