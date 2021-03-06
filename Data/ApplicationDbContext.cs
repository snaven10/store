using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using store.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace store.Data
{
    public class ApplicationDbContext:IdentityDbContext<users>
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
            this.SeedUsers(builder);
            this.SeedRoles(builder);
            this.SeedUserRoles(builder);
            this.SeedStore(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            users user = new users()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@gmail.com",
                FirsName = "Samuel",
                LastName = "Funes",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                NormalizedUserName = "admin@gmail.com".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                PhoneNumber = "123456789",
                PhoneNumberConfirmed = false
            };

            PasswordHasher<users> ph = new PasswordHasher<users>();
            user.PasswordHash = ph.HashPassword(user, "Admin@123");

            builder.Entity<users>().HasData(
                user
            );
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "ADMIN", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "NORMAL", ConcurrencyStamp = "2", NormalizedName = "NORMAL" }
            );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }

        private void SeedStore(ModelBuilder builder)
        {
            stores store = new stores()
            {
                IdStore = 1,
                Nombre = "Pasteleria la fe",
                Direccion = "Ciudad pasifica",
                Telefono = "1234578",
                Longitud = "-88.218421",
                Latitud = "13.486709"
            };
            builder.Entity<stores>().HasData(
                store
            );

        }
        public DbSet<stores> Stores { get; set; }
        public DbSet<users> Users { get; set; }
    }
}
