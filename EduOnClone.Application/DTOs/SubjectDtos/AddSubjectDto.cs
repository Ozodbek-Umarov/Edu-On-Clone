using EduOnClone.Domain.Entities;

namespace EduOnClone.Application.DTOs.SubjectDtos;

public class AddSubjectDto
{
    public string SubjectName { get; set; } = string.Empty;
    public string SubjectDescription { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

    public static implicit operator Subject(AddSubjectDto dto)
    {
        return new Subject
        {
            SubjectName = dto.SubjectName,
            SubjectDescription = dto.SubjectDescription,
            Author = dto.Author,
        };
    }
}
