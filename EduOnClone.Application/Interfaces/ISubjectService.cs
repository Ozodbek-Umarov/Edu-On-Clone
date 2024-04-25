using EduOnClone.Application.DTOs.SubjectDtos;

namespace EduOnClone.Application.Interfaces;

public interface ISubjectService
{
    Task CreateAsync(AddSubjectDto dto);
    Task UpdateAsync(SubjectDto dto);
    Task DeleteAsync(int id);
    Task<List<SubjectDto>> GetAllAsync();
    Task<SubjectDto?> GetByIdAsync(int id);
    Task<SubjectDto?> GetByNameAsync(string name);
}
