using EduOnClone.Domain.Entities;

namespace EduOnClone.Data.Interfaces;

public interface IScienceRepository : IGenericRepository<Science>
{
    Task<List<Science>> GetByNameAsync(string name);
}
