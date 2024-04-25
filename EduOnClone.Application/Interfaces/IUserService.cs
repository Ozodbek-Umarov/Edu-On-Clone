using EduOnClone.Application.DTOs.UserDtos;

namespace EduOnClone.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(int id);
    Task<List<UserDto>> GetAllAsync();
    Task UpdateAsync(int id, UpdateUserDto dto);
    Task DeleteAsync(int id);
}
