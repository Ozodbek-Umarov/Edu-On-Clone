using EduOnClone.Data.DbContexts;
using EduOnClone.Data.Interfaces;
using EduOnClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduOnClone.Data.Repositories;

public class TestRepository(AppDbContext dbContext) : GenericRepository<Test>(dbContext), ITestRepository
{
    public async Task<Test?> GetByQuestionAsync(string question)
    {
        return await _dbContext.Tests.FirstOrDefaultAsync(x => x.Question == question);
    }
}
