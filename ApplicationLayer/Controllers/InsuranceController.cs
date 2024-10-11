using DataAccessLayer.Contacts;
using DataAccessLayer.DTOs.InputModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceRepository _insuranceRepository;

        public InsuranceController(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInsurances()
        {
            var result = await _insuranceRepository.GetAllInsurancesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInsuranceById(int id)
        {
            var result = await _insuranceRepository.GetInsuranceByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddInsurance([FromBody] InsuranceInputModel inputModel)
        {
            var result = await _insuranceRepository.AddInsuranceAsync(inputModel);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInsurance(int id, [FromBody] InsuranceInputModel inputModel)
        {
            var result = await _insuranceRepository.UpdateInsuranceAsync(id, inputModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurance(int id)
        {
            var result = await _insuranceRepository.DeleteInsuranceAsync(id);
            return Ok(result);
        }
    }

}
