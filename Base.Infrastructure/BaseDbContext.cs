﻿using System.Data.Entity;
using Base.Infrastructure.Model;

namespace Base.Infrastructure
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext():base("name=DefaultConnection")
        {
           Database.SetInitializer<BaseDbContext>(null); 
        }

        public DbSet<GalleryItemCategory> GalleryItemCategories { get; set; }
        public DbSet<GalleryItem> GalleryItems { get; set; }
        public DbSet<News> News { get; set; }

        public DbSet<ApplicationInfo> ApplicationInfo { get; set; }  
    }
}