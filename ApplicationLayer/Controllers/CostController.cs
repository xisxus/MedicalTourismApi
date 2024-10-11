using DataAccessLayer.Contacts;
using DataAccessLayer.DTOs.InputModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CostController : ControllerBase
    {
        private readonly ICostRepository _costRepository;

        public CostController(ICostRepository costRepository)
        {
            _costRepository = costRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCosts()
        {
            var result = await _costRepository.GetAllCostsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCostById(int id)
        {
            var result = await _costRepository.GetCostByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCost([FromBody] CostInputModel inputModel)
        {
            var result = await _costRepository.AddCostAsync(inputModel);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCost(int id, [FromBody] CostInputModel inputModel)
        {
            var result = await _costRepository.UpdateCostAsync(id, inputModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCost(int id)
        {
            var result = await _costRepository.DeleteCostAsync(id);
            return Ok(result);
        }
    }

}
