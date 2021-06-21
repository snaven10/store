using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using store.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace store.Data
{
    public class ApplicationDbContext : IdentityDbContext<users>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<users>(entityTypeBuilder => {
                entityTypeBuilder.Property(u => u.FirsName)
                .HasMaxLength(50)
                .HasDefaultValue(0);

                entityTypeBuilder.Property(u => u.LastName)
                .HasMaxLength(50)
                .HasDefaultValue(0);

            });
        }
        public DbSet<stores> Stores { get; set; }
    }
}
