using EduOnClone.Domain.Entities;
using EduOnClone.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EduOnClone.Data.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Science> Sciences { get; set; }
    public DbSet<Option> Options { get; set; }
    public DbSet<Test> Tests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "Ozodbek",
                LastName = "Umarov",
                Email = "ozodchik.krasavchik@gmail.com",
                Gender = Gender.Male,
                Password = "f40f5198-f995-4212-8604-cfef53690471",
                Role = Role.SuperAdmin
            });
    }
}
