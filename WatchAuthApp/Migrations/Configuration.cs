namespace WatchAuthApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WatchAuthApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WatchAuthApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WatchAuthApp.Models.ApplicationDbContext";
        }

        protected override void Seed(WatchAuthApp.Models.ApplicationDbContext context)
        {
            //Category cat_horror = new Category() { Name = "Horror" };
            //Category cat_comedy = new Category() { Name = "Comedy" };
            //Category cat_scifi = new Category() { Name = "Sci-Fi" };
            //Category cat_action = new Category() { Name = "Action" };
            //context.Categories.AddOrUpdate(x => x.Name, cat_horror);
            //context.Categories.AddOrUpdate(x => x.Name, cat_comedy);
            //context.Categories.AddOrUpdate(x => x.Name, cat_scifi);
            //context.Categories.AddOrUpdate(x => x.Name, cat_action);

            //Director dir_tarantino = new Director() { Name = "Quentin Tarantino", Age = 56 };
            //Director dir_kubrick = new Director() { Name = "Stanley Kubrick", Age = 98 };
            //Director dir_aronofsky = new Director() { Name = "Darren Aronofsky", Age = 50 };
            //context.Directors.AddOrUpdate(x => x.Name, dir_aronofsky);
            //context.Directors.AddOrUpdate(x => x.Name, dir_tarantino);
            //context.Directors.AddOrUpdate(x => x.Name, dir_kubrick);

            //Actor act_travolta = new Actor() { Name = "John Travolta", Age = 52 };
            //Actor act_ford = new Actor() { Name = "Harrison Ford", Age = 68 };
            //Actor act_tom = new Actor() { Name = "Tom Cruise", Age = 51 };
            //context.Actors.AddOrUpdate(x => x.Name, act_tom);
            //context.Actors.AddOrUpdate(x => x.Name, act_ford);
            //context.Actors.AddOrUpdate(x => x.Name, act_travolta);

            //context.SaveChanges();

            //Movie mov_killbill = new Movie()
            //{
            //    Title = "Kill Bill",
            //    Year = 2003,
            //    Watched=false,
            //    Director = dir_tarantino,
            //    Category = cat_action,

            //};
            //mov_killbill.Actors.Add(act_travolta);
            //mov_killbill.Actors.Add(act_tom);
            //context.SaveChanges();

            //var userstore = new UserStore<ApplicationUser>(context);
            //ApplicationUserManager userManager = new ApplicationUserManager(userstore);
            //var rolestore = new RoleStore<IdentityRole>(context);
            //RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(rolestore);
            //string email = "admin@gmail.com";
            //string username = "admin";
            //string password = "iamtheadmin";
            //string roleName = "Admin";

            //IdentityRole role = roleManager.FindByName(roleName);
            //if (role == null)
            //{
            //    role=new IdentityRole(roleName);
            //    roleManager.Create(role);
            //}

            //ApplicationUser user = userManager.FindByName(username);
            //if (user == null)
            //{
            //    user = new ApplicationUser() { UserName = email, Email = email };
            //    userManager.Create(user, password);
            //}
            //if (!userManager.IsInRole(user.Id, role.Name))
            //{
            //    userManager.AddToRole(user.Id, role.Name);
            //}
        }
    }
}
