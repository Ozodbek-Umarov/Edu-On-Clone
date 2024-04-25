using EduOnClone.Domain.Entities;

namespace EduOnClone.Application.Interfaces;

public interface IAuthManager
{
    string GeneratedToken(User user);
}
