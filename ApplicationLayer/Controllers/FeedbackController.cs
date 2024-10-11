using DataAccessLayer.Contacts;
using DataAccessLayer.DTOs.InputModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            var result = await _feedbackRepository.GetAllFeedbacksAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            var result = await _feedbackRepository.GetFeedbackByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedback([FromBody] FeedbackInputModel inputModel)
        {
            var result = await _feedbackRepository.AddFeedbackAsync(inputModel);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, [FromBody] FeedbackInputModel inputModel)
        {
            var result = await _feedbackRepository.UpdateFeedbackAsync(id, inputModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var result = await _feedbackRepository.DeleteFeedbackAsync(id);
            return Ok(result);
        }
    }

}
