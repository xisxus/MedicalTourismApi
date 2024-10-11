using DataAccessLayer.Contacts;
using DataAccessLayer.DTOs.InputModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        private readonly IGuideRepository _guideRepository;

        public GuideController(IGuideRepository guideRepository)
        {
            _guideRepository = guideRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGuides()
        {
            var result = await _guideRepository.GetAllGuidesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuideById(int id)
        {
            var result = await _guideRepository.GetGuideByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddGuide([FromBody] GuideInputModel inputModel)
        {
            var result = await _guideRepository.AddGuideAsync(inputModel);
            return CreatedAtAction(nameof(GetGuideById), new { id = result.Data.GuideId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuide(int id, [FromBody] GuideInputModel inputModel)
        {
            var result = await _guideRepository.UpdateGuideAsync(id, inputModel);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuide(int id)
        {
            var result = await _guideRepository.DeleteGuideAsync(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return NoContent(); // Status 204
        }
    }
}
