using DataAccessLayer.Contacts;
using DataAccessLayer.DTOs.InputModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FollowUpController : ControllerBase
    {
        private readonly IFollowUpRepository _followUpRepository;

        public FollowUpController(IFollowUpRepository followUpRepository)
        {
            _followUpRepository = followUpRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFollowUps()
        {
            var result = await _followUpRepository.GetAllFollowUpsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFollowUpById(int id)
        {
            var result = await _followUpRepository.GetFollowUpByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddFollowUp([FromBody] FollowUpInputModel inputModel)
        {
            var result = await _followUpRepository.AddFollowUpAsync(inputModel);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFollowUp(int id, [FromBody] FollowUpInputModel inputModel)
        {
            var result = await _followUpRepository.UpdateFollowUpAsync(id, inputModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFollowUp(int id)
        {
            var result = await _followUpRepository.DeleteFollowUpAsync(id);
            return Ok(result);
        }
    }

}
