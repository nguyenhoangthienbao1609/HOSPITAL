using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public AuthController(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            
            var authResult = _authService.Authenticate(request);

            if (authResult == null)
            {
                return Unauthorized(new { Message = "Sai tài khoản hoặc mật khẩu!" });
            }

            
            var userMenus = await _userRepository.GetUserMenusAsync(authResult.userid);

            
            return Ok(new
            {
                Message = "Đăng nhập thành công",
                Data = new
                {
                    token = authResult.token,
                    userid = authResult.userid,
                    menus = userMenus // Bơm luôn danh sách Menu vào đây!
                }
            });
        }
    }
}