using ProfileApiCosmos.Models.DTOs;

namespace ProfileApiCosmos.Providers
{
    public interface IRequestUserProvider
    {
        UserInfo? GetUserInfo();
    }
}
