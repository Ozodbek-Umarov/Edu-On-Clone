using EduOnClone.Domain.Entities;

namespace EduOnClone.Application.DTOs.ScienceDtos;

public class ScienceDto : AddScienceDto
{
    public int Id { get; set; }
    public Subject Subject { get; set; } = null!;

    public static implicit operator ScienceDto(Science science)
    {
        return new ScienceDto()
        {
            Id = science.Id,
            Subject = science.Subject,
            Author = science.Author,
            Description = science.Description,
            Name = science.Name,
            Title = science.Title,
        };
    }
}
