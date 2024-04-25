using EduOnClone.Domain.Entities;

namespace EduOnClone.Application.DTOs.ScienceDtos;

public class AddScienceDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int SubjectId { get; set; }

    public static implicit operator Science(AddScienceDto dto)
    {
        return new Science
        {
            Name = dto.Name,
            Description = dto.Description,
            Title = dto.Title,
            Author = dto.Author,
            SubjectId = dto.SubjectId,
        };
    }
}
