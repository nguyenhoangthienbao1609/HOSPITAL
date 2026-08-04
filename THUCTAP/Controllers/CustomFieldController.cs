using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomFieldController : ControllerBase
    {
        private readonly IFormFieldRepository _formFieldRepository;

        public CustomFieldController(IFormFieldRepository formFieldRepository)
        {
            _formFieldRepository = formFieldRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomField([FromBody] CustomFieldCreateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdField = await _formFieldRepository.CreateFormFieldAsync(request);

            return Ok(new { Message = "Thêm Custom Field thành công", Data = createdField });
        }
    }
}