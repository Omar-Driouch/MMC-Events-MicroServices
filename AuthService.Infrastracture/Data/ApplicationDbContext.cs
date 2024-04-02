using AuthService.Domain.Entities;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastracture.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Role> Roles {  get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship between User and Role
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.ApplicationUserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.applicationUser)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.ApplicationUserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.role) 
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // Seed data if needed
            // modelBuilder.Entity<User>().HasData(new User { ... });
            // modelBuilder.Entity<Role>().HasData(new Role { ... });
        }

    }
}
