using ProfileApiCosmos.Models.DTOs;
using System.Security.Claims;

namespace ProfileApiCosmos.Providers
{
    public class RequestUserProvider : IRequestUserProvider
    {
        private readonly HttpContext _context;

        public RequestUserProvider(IHttpContextAccessor accessor)
        {
            _context = accessor.HttpContext!;
        }

        public UserInfo? GetUserInfo()
        {
            if (!_context.User.Claims.Any()) return null;

            var userId = _context.User.Claims.First(e => e.Type == "userId").Value;
            var username = _context.User.Identity!.Name!;
            var email = _context.User.Claims.First(e => e.Type == ClaimTypes.Email).Value;
            return new UserInfo(userId, username, email);
        }
    }
}
