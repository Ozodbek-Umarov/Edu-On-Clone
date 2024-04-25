using EduOnClone.Data.DbContexts;
using EduOnClone.Data.Interfaces;
using EduOnClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduOnClone.Data.Repositories;

public class SubjectRepository(AppDbContext dbContext) : GenericRepository<Subject>(dbContext), ISubjectRepository
{
    public async Task<Subject?> GetByNameAsync(string name)
    {
        return await _dbContext.Subjects.FirstOrDefaultAsync(x => x.SubjectName == name);
    }
}
