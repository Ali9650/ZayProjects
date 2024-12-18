﻿using Microsoft.EntityFrameworkCore;
using Zay_Projects.Entities;

namespace Zay_Projects.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<BrandPhoto> BrandPhotos { get; set; }
    }
}
