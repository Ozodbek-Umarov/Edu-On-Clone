using EduOnClone.Data.DbContexts;
using EduOnClone.Data.Interfaces;
using EduOnClone.Domain.Entities;

namespace EduOnClone.Data.Repositories;

public class OptionsRepository(AppDbContext dbContext) : GenericRepository<Option>(dbContext), IOptionRepository
{
}
