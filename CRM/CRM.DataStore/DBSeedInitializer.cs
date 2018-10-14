using System.Linq;
using System.Threading.Tasks;
using CRM.Models.Dbo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.DataStore
{
    public class DBSeedInitializer
    {

        static string role1 = "Admin";
        static string desc1 = "Administrator role";

        static string role2 = "Member";
        static string desc2 = "Members role";

        static string role3 = "Guest";
        static string desc3 = "Guest role";

        static string password = "Pentium@1234";

        public DBSeedInitializer(UserManager<User> userManager,
                                   RoleManager<Role> roleManager, CRMDBContext context)
        {
            this.RoleManager = roleManager;
            this.UserManager = userManager;
            this.Context = context;
        }

        public RequestDelegate Next { get; private set; }
        public CRMDBContext Context { get; private set; }
        public UserManager<User> UserManager { get; private set; }
        public RoleManager<Role> RoleManager { get; private set; }


        public void Seed()
        {

            if (!Context.Roles.Any())
            {
                CreateRoles();
            }
            if (!Context.Users.Any())
            {
                CreateUsers();
            }
        }


        private void CreateRoles()
        {
            Role role = null;
            if (RoleManager.FindByNameAsync(role1).Result == null)
            {

                role = new Role();
                role.Name = role1;
                role.Description = desc1;
                RoleManager.CreateAsync(role).Wait();
            }

            if (RoleManager.FindByNameAsync(role2).Result == null)
            {

                role = new Role();
                role.Name = role2;
                role.Description = desc2;
                RoleManager.CreateAsync(role).Wait();
            }

            if (RoleManager.FindByNameAsync(role3).Result == null)
            {
                role = new Role();
                role.Name = role3;
                role.Description = desc3;
                RoleManager.CreateAsync(role);
            }
        }

        private void CreateUsers()
        {
            User user = null;
            if (UserManager.FindByNameAsync("AdminUser").Result == null)
            {
                user = new User();
                user.UserName = "AdminUser";
                user.Email = "AdminUser@AdminUser.com";
                user.FirstName = "AdminUser";
                user.LastName = "AdminUser";
                user.PhoneNumber = "9988888899";
                UserManager.CreateAsync(user).Wait();
                UserManager.AddPasswordAsync(user, password).Wait();
                UserManager.AddToRoleAsync(user, role1).Wait();
            }

            if (UserManager.FindByNameAsync("MemberUser").Result == null)
            {
                user = new User();
                user.UserName = "MemberUser";
                user.Email = "MemberUser@MemberUser.com";
                user.FirstName = "MemberUser";
                user.LastName = "MemberUser";
                user.PhoneNumber = "889889998";
                UserManager.CreateAsync(user).Wait();
                UserManager.AddPasswordAsync(user, password).Wait();
                UserManager.AddToRoleAsync(user, role2).Wait();
            }

            if (UserManager.FindByNameAsync("GuestUser").Result == null)
            {
                user = new User();
                user.UserName = "GuestUser";
                user.Email = "GuestUser@GuestUser.com";
                user.FirstName = "GuestUser";
                user.LastName = "GuestUser";
                user.PhoneNumber = "8898899966";
                UserManager.CreateAsync(user).Wait();
                UserManager.AddPasswordAsync(user, password).Wait();
                UserManager.AddToRoleAsync(user, role3).Wait();
            }


        }
    }

}