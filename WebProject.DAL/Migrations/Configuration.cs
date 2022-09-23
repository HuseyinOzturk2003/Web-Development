namespace WebProject.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebProject.DAL.Concrete.WebDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

       //In this section, Migration is started, that is, tables are built with the codes written to the database.

        protected override void Seed(WebProject.DAL.Concrete.WebDatabase context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
