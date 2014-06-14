using Base.Infrastructure.Model;

namespace Base.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Base.Infrastructure.BaseDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Base.Infrastructure.BaseDbContext context)
        {
            ApplicationInfo app = new ApplicationInfo
            {
                ApplicationName = "Appliacation Name",
                CompanyName =  "Company Name",
                HeaderText = "",
                LogoPath = "~/Content/Images/logo.png",
                HeaderBackground = "~/Content/Images/Header-bg.png",
                IsHeaderImage = true
            };
            context.ApplicationInfo.Add(app);
            context.SaveChanges();
        }
    }
}
