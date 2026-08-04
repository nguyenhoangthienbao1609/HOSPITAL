using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupRequest request)
        {
            try
            {
                var createdGroup = await _groupRepository.CreateGroupWithPermissionsAsync(request);

                return Ok(new
                {
                    Message = "Tạo nhóm và phân quyền thành công!",
                    Data = createdGroup
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Lỗi khi tạo nhóm: " + ex.Message });
            }
        }
    }
}