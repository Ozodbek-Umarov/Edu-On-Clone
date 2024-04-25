using EduOnClone.Data.DbContexts;
using EduOnClone.Data.Interfaces;

namespace EduOnClone.Data.Repositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;
    public IScienceRepository Science => new ScienceRepository(_dbContext);

    public ISubjectRepository Subject => new SubjectRepository(_dbContext);

    public IUserRepository User => new UserRepository(_dbContext);

    public ITestRepository Test => new TestRepository(_dbContext);

    public IOptionRepository Option => new OptionsRepository(_dbContext);
}
