using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileApiCosmos.Data;
using ProfileApiCosmos.Providers;
using ProfileApiCosmos.Services.Interfaces;

namespace ProfileApiCosmos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProfileController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IStorageManager _storageManager;
        private readonly AppDbContextCosmos _context;
        private readonly IRequestUserProvider _provider;


        public ProfileController(IUserService userService, IStorageManager storageManager, AppDbContextCosmos context, IRequestUserProvider provider)
        {
            _userService = userService;
            _storageManager = storageManager;
            _context = context;
            _provider=provider;
        }

        [HttpGet("profilePhoto")]
        public async Task<ActionResult<bool>> GetPPAsync()
        {
            var user = await _userService.FindUserByEmailAsync(_provider.GetUserInfo().email);
            if (user is null)
                return false;

            var url = _storageManager.GetSignedUrl(user.ProfilePhoto);
            return Ok(url);
        }

        [HttpPut("changeProfilePicture")]
        public async Task<ActionResult> ChangePPAsync(IFormFile file)
        {
            var user = await _userService.FindUserByEmailAsync(_provider.GetUserInfo().email);
            if (user is null)
                return BadRequest();
            var id = await _storageManager.UploadFileAsync(file.OpenReadStream(), file.FileName, file.ContentType);

            await _storageManager.DeleteFileAsync(user.ProfilePhoto);
            user.ProfilePhoto = id;
            _context.Update(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
