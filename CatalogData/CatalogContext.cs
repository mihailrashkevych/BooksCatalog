using AutoMapper.Configuration;
using CatalogData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogData
{
    public class CatalogContext : DbContext
    {
        Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public CatalogContext(Microsoft.Extensions.Configuration.IConfiguration configuration) : base()
        {
            this._configuration = configuration;
            DbInitializer.Initialize(this);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().HasMany(a => a.Books).WithOne(b => b.Category);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
