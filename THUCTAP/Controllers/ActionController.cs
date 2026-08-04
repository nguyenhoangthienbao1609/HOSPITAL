using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly IActionRepository _actionRepository;

        public ActionController(IActionRepository actionRepository)
        {
            _actionRepository = actionRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAction([FromBody] ActionCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAction = await _actionRepository.CreateActionAsync(request);

            return Ok(new
            {
                Message = "Thêm Form Action thành công",
                Data = createdAction
            });
        }
    }
}