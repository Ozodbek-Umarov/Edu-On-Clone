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
                Password = "186cf774c97b60a1c106ef718d10970a6a06e06bef89553d9ae65d938a886eae",
                Role = Role.SuperAdmin
            });
    }
}

