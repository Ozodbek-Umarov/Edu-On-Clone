using EduOnClone.Domain.Entities;

namespace EduOnClone.Data.Interfaces;

public interface ISubjectRepository : IGenericRepository<Subject>
{
    Task<Subject?> GetByNameAsync(string name);
}
