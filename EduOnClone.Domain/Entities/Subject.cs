namespace EduOnClone.Domain.Entities;

public class Subject : BaseEntity
{
    public string SubjectName { get; set; } = string.Empty;
    public string SubjectDescription { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public DateTime? SubjectDate { get; set; } = DateTime.UtcNow;
}
