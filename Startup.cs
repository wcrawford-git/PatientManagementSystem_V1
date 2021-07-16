using Microsoft.Owin;
using Owin;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PatientManagementSystem.Models;

[assembly: OwinStartupAttribute(typeof(PatientManagementSystem.Startup))]
namespace PatientManagementSystem
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();  

        }
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // creating Creating Manager role     
            if (!roleManager.RoleExists(RoleName.User))
            {
                var role = new IdentityRole();
                role.Name = RoleName.User;
                roleManager.Create(role);

            }

            // creating Creating Employee role     
            if (!roleManager.RoleExists(RoleName.Doctor))
            {
                var role = new IdentityRole();
                role.Name = RoleName.Doctor;
                roleManager.Create(role);

            }

        }

    }
}
