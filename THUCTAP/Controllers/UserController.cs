using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateRequest request)
        {
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdUser = await _userRepository.CreateUserAsync(request);
                var token = _tokenService.GenerateToken(createdUser);


                return Ok(new
                {
                    Message = "Thêm người dùng thành công",
                    Data = createdUser,
                    Token = token
                });
            }
        }
        
    
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            {
                var users = await _userRepository.GetAllUsersWithPermissionsAsync();

                return Ok(new
                {
                    Message = "Lấy danh sách người dùng thành công",
                    Data = users
                });
            }
        }
    }
}