using EduOnClone.Application.DTOs.ScienceDtos;

namespace EduOnClone.Application.Interfaces;

public interface IScienceService
{
    Task CreateAsync(AddScienceDto dto);
    Task UpdateAsync(ScienceDto dto);
    Task DeleteAsync(int id);
    Task<List<ScienceDto>> GetAllAsync();
    Task<ScienceDto> GetByIdAsync(int id);
    Task<List<ScienceDto>> GetByNameAsync(string name);
}
