using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsApp.Data.Entities;
using ContactsApp.Shared.Enums;
using ContactsApp.Shared.Security;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Data
{
    public class ContactsAppWebContext : DbContext
    {
        public ContactsAppWebContext (DbContextOptions<ContactsAppWebContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Contacts)
                .WithOne(c => c.Group)
                .HasForeignKey(c => c.GroupId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Groups)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Contacts)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            foreach (var role in Enum.GetValues(typeof(UserRole)).Cast<UserRole>())
            {
                modelBuilder.Entity<Role>().HasData(new Role { Id = (int)role, Name = role.ToString() });
            }

            modelBuilder.Entity<User>()
                .HasData(new User { 
                    Id = 1,
                    Username = "admin",
                    RoleId = (int)UserRole.Admin,
                    FirstName = "Admin",
                    LastName = "User",
                    Password = PasswordHasher.HashPassword("string")
                });

            modelBuilder.Entity<Group>()
                .HasData(new Group
                {
                    Id = 1,
                    Name = "None",
                    UserId = 1
                },
                new Group
                {
                    Id = 2,
                    Name = "Family",
                    UserId = 1
                });

            modelBuilder.Entity<Contact>()
                .HasData(new Contact
                {
                    Id = 1,
                    Name = "Steve Steve",
                    Phone = "0884734353",
                    Email = "stevesteve@gmail.com",
                    Address = "Gatorlake, Florida",
                    GroupId = 1,
                    UserId = 1
                });
        }

        public DbSet<Contact> Contacts { get; set; } = default!;
        public DbSet<Group> Groups { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;
    }
}
