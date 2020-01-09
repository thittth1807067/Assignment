using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Assignment_P3.Models;

namespace Assignment_P3.App_Start
{
    public class IdentityConfig
    {
        public class ApplicationUserManager : UserManager<AppUser>
        {
            public ApplicationUserManager(IUserStore<AppUser> store)
                : base(store)
            {
            }

            public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
                IOwinContext context)
            {
                var manager =
                    new ApplicationUserManager(new UserStore<AppUser>(context.Get<MyDBContext>()));
                return manager;
            }
        }
    }
}