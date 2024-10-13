using DataAccessLayer.Contacts;
using DataAccessLayer.DTOs.InputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        private readonly IFacilitiesRepository _facilitiesRepository;

        public FacilitiesController(IFacilitiesRepository facilitiesRepository)
        {
            _facilitiesRepository = facilitiesRepository;
        }

        // GET: api/Facilities
        [HttpGet("get")]
        public async Task<IActionResult> GetAllFacilities()
        {
            var facilities = await _facilitiesRepository.GetAllFacilitiesAsync();
            return Ok(facilities);
        }

        // GET: api/Facilities/{id}
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetFacilitiesById(int id)
        {
            var facility = await _facilitiesRepository.GetFacilitiesByIdAsync(id);
            if (facility == null)
            {
                return NotFound();
            }
            return Ok(facility);
        }

        // POST: api/Facilities
        [HttpPost("add")]
        public async Task<IActionResult> CreateFacilities([FromBody] FacilitiesInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdFacility = await _facilitiesRepository.AddFacilitiesAsync(inputModel);
            return CreatedAtAction(nameof(GetFacilitiesById), new { id = createdFacility.FacilitiesId }, createdFacility);
        }

        // PUT: api/Facilities/{id}
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdateFacilities(int id, [FromBody] FacilitiesInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedFacility = await _facilitiesRepository.UpdateFacilitiesAsync(id, inputModel);
            if (updatedFacility == null)
            {
                return NotFound();
            }

            return Ok(updatedFacility);
        }

        // DELETE: api/Facilities/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFacilities(int id)
        {
            var result = await _facilitiesRepository.DeleteFacilitiesAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
