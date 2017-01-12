namespace WebApplication6.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication6.Models.ResponseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApplication6.Models.ResponseContext";
        }

        protected override void Seed(WebApplication6.Models.ResponseContext context)
        {
            
        }
    }
}
