using DataAccessLayer.Contacts;
using DataAccessLayer.DTOs.InputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalFacilitiesController : ControllerBase
    {
        private readonly IHospitalFacilitiesRepository _hospitalFacilitiesRepository;

        public HospitalFacilitiesController(IHospitalFacilitiesRepository hospitalFacilitiesRepository)
        {
            _hospitalFacilitiesRepository = hospitalFacilitiesRepository;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllHospitalFacilities()
        {
            var facilities = await _hospitalFacilitiesRepository.GetAllHospitalFacilitiesAsync();
            return Ok(facilities);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetHospitalFacilities(int id)
        {
            var facility = await _hospitalFacilitiesRepository.GetHospitalFacilitiesByIdAsync(id);

            if (facility == null)
            {
                return NotFound();
            }

            return Ok(facility);
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateHospitalFacilities([FromBody] HospitalFacilitiesInModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdFacility = await _hospitalFacilitiesRepository.CreateHospitalFacilitiesAsync(model);
            return CreatedAtAction(nameof(GetHospitalFacilities), new { id = createdFacility.HospitalFacilitiesId }, createdFacility);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdateHospitalFacilities(int id, [FromBody] HospitalFacilitiesInModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedFacility = await _hospitalFacilitiesRepository.UpdateHospitalFacilitiesAsync(id, model);
            if (updatedFacility == null)
            {
                return NotFound();
            }

            return Ok(updatedFacility);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteHospitalFacilities(int id)
        {
            var success = await _hospitalFacilitiesRepository.DeleteHospitalFacilitiesAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
