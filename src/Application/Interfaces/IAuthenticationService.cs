using Application.Models;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        public string GenerateToken(UserAuth user);
    }
}
