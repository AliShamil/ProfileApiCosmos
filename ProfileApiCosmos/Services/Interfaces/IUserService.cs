using ProfileApiCosmos.Models;
using ProfileApiCosmos.Models.DTOs;

namespace ProfileApiCosmos.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> RegisterAsync(RegisterDTO model);
        Task<bool> LoginAsync(LoginDTO model);
        public Task<User?> FindUserByEmailAsync(string email);
    }
}
