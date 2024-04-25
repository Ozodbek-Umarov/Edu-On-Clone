using EduOnClone.Data.DbContexts;
using EduOnClone.Data.Interfaces;
using EduOnClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduOnClone.Data.Repositories;

public class ScienceRepository(AppDbContext dbContext) : GenericRepository<Science>(dbContext), IScienceRepository
{
    public async Task<List<Science>> GetByNameAsync(string name)
    {
        var science = await _dbContext.Sciences.ToListAsync();
        return science.Where(s => s.Title.ToLower().Contains(name.ToLower())).ToList();
    }
}
