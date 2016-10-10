using Microsoft.Owin;
using Owin;
using BCMS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(BCMS.Startup))]
namespace BCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.Email = "hanygoda@outlook.com";
                user.FirstName = "Hany";
                user.MiddleName = "Goda";
                user.LastName = "Mostafa";
                user.UserName= "hanygoda@outlook.com";
                string password = "Hany@2051990";
                user.EmailConfirmed = true;
                user.UserStatus = UserStatus.Active;
                var result = userManager.Create(user, password);
                if (result.Succeeded)
                {
                    var roleResult = userManager.AddToRole(user.Id, "Admin");
                }
            }


        }
    }
}
