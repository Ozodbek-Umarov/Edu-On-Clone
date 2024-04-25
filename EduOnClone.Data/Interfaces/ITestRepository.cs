using EduOnClone.Domain.Entities;

namespace EduOnClone.Data.Interfaces;

public interface ITestRepository : IGenericRepository<Test>
{
    Task<Test?> GetByQuestionAsync(string question);
}
