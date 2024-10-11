using DataAccessLayer.Contacts;
using DataAccessLayer.DTOs.InputModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplainController : ControllerBase
    {
        private readonly IComplainRepository _complainRepository;

        public ComplainController(IComplainRepository complainRepository)
        {
            _complainRepository = complainRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComplains()
        {
            var result = await _complainRepository.GetAllComplainsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComplainById(int id)
        {
            var result = await _complainRepository.GetComplainByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddComplain([FromBody] ComplainInputModel inputModel)
        {
            var result = await _complainRepository.AddComplainAsync(inputModel);
            return CreatedAtAction(nameof(GetComplainById), new { id = result.Data.ComplainId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComplain(int id, [FromBody] ComplainInputModel inputModel)
        {
            var result = await _complainRepository.UpdateComplainAsync(id, inputModel);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplain(int id)
        {
            var result = await _complainRepository.DeleteComplainAsync(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return NoContent(); // Status 204
        }
    }
}
