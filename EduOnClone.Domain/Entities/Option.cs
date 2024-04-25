using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduOnClone.Domain.Entities;

public class Option : BaseEntity
{
    public string Variant { get; set; } = string.Empty;

    public int TestId { get; set; }
    [ForeignKey(nameof(TestId))]
    public Test Test { get; set; } = null!;
}
