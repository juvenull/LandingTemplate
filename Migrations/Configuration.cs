namespace LandingTemplate.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LandingTemplate.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LandingTemplate.Models.LandingTemplateContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LandingTemplate.Models.LandingTemplateContext context)
        {
            context.Goods.AddOrUpdate(x => x.Id,
                new Good() { Id = 1, Title = "Товар 1", Amount = 1, Price = 1000 },
                new Good() { Id = 2, Title = "Товар 2", Amount = 1, Price = 1000 },
                new Good() { Id = 3, Title = "Товар 3", Amount = 1, Price = 1000 }
            );
        }
    }
}
