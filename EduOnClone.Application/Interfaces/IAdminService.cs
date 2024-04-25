using EduOnClone.Domain.Entities;

namespace EduOnClone.Application.Interfaces;

public interface IAdminService
{
    Task ChangeUserRoleAsync(int id);
    Task DeleteUserAsync(int id);
    Task<List<User>> GetAllAdminAsync();
}
