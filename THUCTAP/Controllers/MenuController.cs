//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using THUCTAP.Interfaces;

//namespace THUCTAP.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class MenuController : ControllerBase
//    {
//        private readonly IMenuService _menuService;
//        private readonly IUserService _userService;

//        public MenuController(IMenuService menuService, IUserService userService)
//        {
//            _menuService = menuService;
//            _userService = userService;
//        }

//        //[HttpGet("full-menu")]
//        //public async Task<IActionResult> GetFullMenu()
//        //{
//        //    var fullMenu = await _menuService.GetFullMenuTreeAsync();
//        //    return Ok(new
//        //    {
//        //        message = "Lấy toàn bộ danh sách Menu thành công!",
//        //        data = fullMenu
//        //    });
//        //}
//    }
        
//}