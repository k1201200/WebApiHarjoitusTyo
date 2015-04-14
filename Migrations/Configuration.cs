namespace WebApiHarjoitusTyo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApiHarjoitusTyo.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiHarjoitusTyo.Models.WebApiHarjoitusTyoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApiHarjoitusTyo.Models.WebApiHarjoitusTyoContext context)
        {
            Random random = new Random();

            int index = 0;

            for (int xPos = 0; xPos <= 9; xPos++)
            {
                for (int yPos = 0; yPos <= 9; yPos++)
                {
                    context.DigSites.AddOrUpdate(x => x.Id, new DigSite() { Id = index + 1, xCoord = xPos, yCoord = yPos, treasureValue = random.Next(0, 999), isClaimed = false, isEmpty = false });
                    index++;
                }
            }   

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
