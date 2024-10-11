using DataAccessLayer.Contacts;
using DataAccessLayer.DTOs.InputModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommissionController : ControllerBase
    {
        private readonly ICommissionRepository _commissionRepository;

        public CommissionController(ICommissionRepository commissionRepository)
        {
            _commissionRepository = commissionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommissions()
        {
            var result = await _commissionRepository.GetAllCommissionsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommissionById(int id)
        {
            var result = await _commissionRepository.GetCommissionByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCommission([FromBody] CommissionInputModel inputModel)
        {
            var result = await _commissionRepository.AddCommissionAsync(inputModel);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommission(int id, [FromBody] CommissionInputModel inputModel)
        {
            var result = await _commissionRepository.UpdateCommissionAsync(id, inputModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommission(int id)
        {
            var result = await _commissionRepository.DeleteCommissionAsync(id);
            return Ok(result);
        }
    }

}
