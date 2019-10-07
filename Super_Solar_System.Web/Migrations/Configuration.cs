namespace Super_Solar_System.Web.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Super_Solar_System.Web.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Super_Solar_System.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Super_Solar_System.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(Super_Solar_System.Web.Models.ApplicationDbContext context)
        {
            // Edw tha dimiourgisw Rolous gia Users, px. Admin, Super Admin, klp

            // Create a new Application User >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (!context.Users.Any(u => u.UserName == "User@gmail.com"))
            {
                // Connection With our DataBase
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "User@gmail.com", Email = "User@gmail.com" }; // Edw den exei akoma dimiourgithei o User
                manager.Create(user, "ABCabc123");
            }

            // Create a Second Application User AND User Role >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            string roleAdmin = "admin";
            string roleSuperAdmin = "superadmin";

            string emailA = "admin@gmail.com";
            string passA = "Admin123";
            string emailSA = "superadmin@gmail.com";
            string passSA = "Superadmin123";


            if (!context.Users.Any(u => u.UserName == "Admin") || !context.Users.Any(u => u.UserName == "SuperAdmin"))
            {

                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user1 = new ApplicationUser { UserName = emailA, Email = passA };
                var user2 = new ApplicationUser { UserName = emailSA, Email = passSA };

                manager.Create(user1, passA);
                manager.Create(user2, passSA);


                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var IdentityRole1 = new IdentityRole { Name = roleAdmin };
                var IdentityRole2 = new IdentityRole { Name = roleSuperAdmin };

                roleManager.Create(IdentityRole1);
                manager.AddToRole(user1.Id, roleAdmin);

                roleManager.Create(IdentityRole2);
                manager.AddToRole(user2.Id, roleSuperAdmin);
            }





        }
    }
}
