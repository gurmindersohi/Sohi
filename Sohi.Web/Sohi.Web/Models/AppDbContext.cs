using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sohi.Web.Models
{
    public class AppDbContext: IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //public DbSet<Leads.Leads> Leads { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");

        }
    }
}
