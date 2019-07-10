using Centroid.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Centroid.Startup))]
namespace Centroid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createDefaultUsers();
        }
        // In this method we will create default User roles and Admin user for login    
        private void createDefaultUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var user = new ApplicationUser();
                user.UserName = "admin@centroid.com";
                user.Email = "admin@centroid.com";

                string userPWD = "Pa$$w0rd";

                var chkUser = UserManager.Create(user, userPWD);

        }
    }
}
