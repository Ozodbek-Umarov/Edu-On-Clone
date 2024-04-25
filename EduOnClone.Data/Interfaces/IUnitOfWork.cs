using EduOnClone.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduOnClone.Data.Interfaces;

public interface IUnitOfWork
{
    IScienceRepository Science {  get; }
    ISubjectRepository Subject { get; }
    IUserRepository User { get; }
    ITestRepository Test { get; }
    IOptionRepository Option { get; }
}
