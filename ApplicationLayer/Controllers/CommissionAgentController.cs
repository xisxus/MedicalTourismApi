using DataAccessLayer.Contacts;
using DataAccessLayer.DTOs.InputModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommissionAgentController : ControllerBase
    {
        private readonly ICommissionAgentRepository _commissionAgentRepository;

        public CommissionAgentController(ICommissionAgentRepository commissionAgentRepository)
        {
            _commissionAgentRepository = commissionAgentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAgents()
        {
            var result = await _commissionAgentRepository.GetAllAgentsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgentById(int id)
        {
            var result = await _commissionAgentRepository.GetAgentByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAgent([FromBody] CommissionAgentInputModel inputModel)
        {
            var result = await _commissionAgentRepository.AddAgentAsync(inputModel);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAgent(int id, [FromBody] CommissionAgentInputModel inputModel)
        {
            var result = await _commissionAgentRepository.UpdateAgentAsync(id, inputModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgent(int id)
        {
            var result = await _commissionAgentRepository.DeleteAgentAsync(id);
            return Ok(result);
        }
    }

}
