using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDynamicMenu([FromBody] MenuCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _menuService.CreateDynamicMenuAsync(request);

                return Ok(new
                {
                    Message = "Tạo Menu và các thành phần thành công!",
                    Data = result
                });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new
                {
                    Message = "Đã xảy ra lỗi khi tạo Menu",
                    Error = ex.Message
                });
            }
        }
    }
}