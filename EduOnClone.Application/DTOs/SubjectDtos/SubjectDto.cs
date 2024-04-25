using EduOnClone.Domain.Entities;

namespace EduOnClone.Application.DTOs.SubjectDtos;

public class SubjectDto : AddSubjectDto
{
    public int Id { get; set; }

    public static implicit operator SubjectDto(Subject subject)
    {
        return new SubjectDto()
        {
            Id = subject.Id,
            SubjectDescription = subject.SubjectDescription,
            SubjectName = subject.SubjectName,
            Author = subject.Author,
        };
    }

    public static implicit operator Subject(SubjectDto dto)
    {
        return new Subject()
        {
            Id = dto.Id,
            SubjectDescription = dto.SubjectDescription,
            SubjectName = dto.SubjectName,
            Author = dto.Author,
        };
    }
}
