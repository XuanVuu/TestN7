namespace QLMP.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QLMP.Models.QLMyPham>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "QLMP.Models.QLMyPham";
        }

        protected override void Seed(QLMP.Models.QLMyPham context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

        }
    }
}
