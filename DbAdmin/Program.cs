using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Collections.Generic;
using System.IO;
using Data_Access_Layer.UnitOfWork;
using Newtonsoft.Json;

namespace DbAdmin
{
    

    class Program
    {
        static void Main(string[] args)
        {
            List<Model.Vinil> vinils = new List<Model.Vinil>();
            using (StreamReader sr = new StreamReader("data.txt", System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Model.Vinil newVinil = JsonConvert.DeserializeObject<Model.Vinil>(line);
                    vinils.Add(newVinil);
                }
            }
            using (UnitOfWork uow = new UnitOfWork())
            {
                //var a = uow.Vinils.GetAllWithStyles();
                foreach (var item in vinils)
                {
                    uow.Vinils.Add(item);
                }
                uow.Save();
            }
            InitializeRoles();
            InitializeUser();
            InitializeAdmin();
            for (;;)
            {
                Console.WriteLine("database update");
                var temp = Console.ReadLine();

            }
            
        }

        private static void InitializeRoles()
        {
            using (var context = new IdentityDbContext("VinilConnectionString"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roles = new[] { "Admin", "User"};
                foreach (var roleName in roles)
                {
                    if (!context.Roles.Any(r => r.Name == roleName))
                    {
                        Task.WaitAll(roleStore.CreateAsync(new IdentityRole(roleName)));
                    }
                }

                context.SaveChanges();
            }
        }

        private static void InitializeUser()
        {
            
            using (var context = new IdentityDbContext("VinilConnectionString"))
            {
                var user = new IdentityUser();
                user.UserName = "User@mail.ru";
                user.Email = "User@mail.ru";
                user.LockoutEnabled = true;
                var userStore = new UserStore<IdentityUser>(context);
                var userManager = new UserManager<IdentityUser>(userStore);
                string password = "User_1";
                userManager.Create(user, password);
                userManager.AddToRole(user.Id, "User");
                context.SaveChanges();
            }
        }
        private static void InitializeAdmin()
        {

            using (var context = new IdentityDbContext("VinilConnectionString"))
            {

                var user = new IdentityUser();
                user.UserName = "Admin@mail.ru";
                user.Email = "Admin@mail.ru";
                user.LockoutEnabled = true;
                var userStore = new UserStore<IdentityUser>(context);
                var userManager = new UserManager<IdentityUser>(userStore);
                string password = "Admin_1";
                userManager.Create(user, password);
                
                userManager.AddToRole(user.Id, "Admin");
                userManager.AddToRole(user.Id, "User");
                context.SaveChanges();
            }
        }
    }
}
