using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var token = _authService.Authenticate(request);

            if (token == null)
            {
                return Unauthorized(new { message = "Sai tài khoản hoặc mật khẩu" });
            }

            return Ok(new
            {
                message = "Đăng nhập thành công!",
                token = token
            });
        }
    }
}