namespace EduOnClone.Domain.Entities;

public class Science : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    

    public int SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;
}
