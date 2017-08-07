namespace DLL.Migrations
{
    using Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DLL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DLL.ApplicationDbContext context)
        {
            //fill user table with data
            if (context.Users.Count() == 0)
            {
                var user1 = new User("Ahmed");
                var user2 = new User("Mohamed");
                var user3 = new User("Yassen");
                var user4 = new User("Youmna");
                var user5 = new User("Radwa");
                var user6 = new User("Hanan");

                var usersList = new List<User>() { user1, user2, user3, user4, user5, user6 };

                context.Users.AddRange(usersList);
                context.SaveChanges();
            }
            

        }
    }
}
