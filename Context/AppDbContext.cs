using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testWebAPI.Models;

namespace testWebAPI.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            this.SeedUserRoles(builder);
            this.SeedRoles(builder);
            this.SeededMovies(builder);
        }
        private void SeedUsers(ModelBuilder builder)
        {
            var user1 = new IdentityUser()
            {
                Id = "634a60ec-96bc-4f37-937f-27ba52f58d41",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM"
            };
            var user2 = new IdentityUser()
            {
                Id = "c80d49e8-a97c-45e6-babf-0760a6b86814",
                UserName = "Rishav@gmail.com",
                NormalizedUserName = "RISHAV@GMAIL.COM",
                Email = "rishav@gmail.com",
                NormalizedEmail = "RISHAV@GMAIL.COM"
            };
            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            user1.PasswordHash = passwordHasher.HashPassword(user1, "Admin@123");
            user2.PasswordHash = passwordHasher.HashPassword(user2, "Rishav@123");
            builder.Entity<IdentityUser>().HasData(user1);
            builder.Entity<IdentityUser>().HasData(user2);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "b31f9c27-4c2d-4f82-9aa8-a5a10382ca98", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "fa6f6c49-37f8-4447-a6bd-1c0a2a1353dc", Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
        );
        }
        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "b31f9c27-4c2d-4f82-9aa8-a5a10382ca98", UserId = "634a60ec-96bc-4f37-937f-27ba52f58d41" }
                );
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fa6f6c49-37f8-4447-a6bd-1c0a2a1353dc", UserId = "c80d49e8-a97c-45e6-babf-0760a6b86814" }
                );
        }
        private void SeededMovies(ModelBuilder builder)
        {
            var movie1 = new Movie()
            {
                Id = 1,
                MovieName = "John Wick Chapter-4",
                MovieDate = DateTime.Now,
                MovieGenre = "Action",
                MovieCast = "Keanu Reeves"
            };
            var movie2 = new Movie()
            {
                Id = 2,
                MovieName = "Ant-Man and The Wasp 3",
                MovieDate = DateTime.Now,
                MovieGenre = "Sci-fi,Action",
                MovieCast = "Paul Rudd"
            };
            var movie3 = new Movie()
            {
                Id = 3,
                MovieName = "Gurdians of the Galaxy Vol3",
                MovieDate = DateTime.Now,
                MovieGenre = "Sci-fi",
                MovieCast = "Chris Pratt"
            };
            var movie4 = new Movie()
            {
                Id = 4,
                MovieName = "Black Adam",
                MovieDate = DateTime.Now,
                MovieGenre = "Action",
                MovieCast = "Dwayne Johnson"
            };
            var movie5 = new Movie()
            {
                Id = 5,
                MovieName = "The Marvels",
                MovieDate = DateTime.Now,
                MovieGenre = "Action,Sci-fi",
                MovieCast = "Brie Larson,Iman Vellani"
            };
            builder.Entity<Movie>().HasData(movie1,movie2,movie3,movie4,movie5);
        }
    }
}

