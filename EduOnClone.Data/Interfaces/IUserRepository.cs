using EduOnClone.Domain.Entities;

namespace EduOnClone.Data.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}
