using DataAccessLayer.Contacts;
using DataAccessLayer.DTOs.InputModels;
using DataAccessLayer.DTOs.OutputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidenceHospitalController : ControllerBase
    {
        private readonly IResidenceHospitalRepository _residenceHospitalRepository;

        public ResidenceHospitalController(IResidenceHospitalRepository residenceHospitalRepository)
        {
            _residenceHospitalRepository = residenceHospitalRepository;
        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<ResidenceHospitalOutputModel>>> GetHospitals()
        {
            var hospitals = await _residenceHospitalRepository.GetAllHospitalsAsync();
            return Ok(hospitals);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<ResidenceHospitalOutputModel>> GetHospital(int id)
        {
            var hospital = await _residenceHospitalRepository.GetHospitalByIdAsync(id);
            if (hospital == null) return NotFound();

            return Ok(hospital);
        }

        [HttpPost("add")]
        public async Task<ActionResult> CreateHospital([FromForm] ResidenceHospitalInputModel model)
        {
            var createdHospital = await _residenceHospitalRepository.AddHospitalAsync(model);
            return CreatedAtAction(nameof(GetHospital), new { id = createdHospital.ResidenceHospitalId }, createdHospital);
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult> UpdateHospital(int id, [FromForm] ResidenceHospitalInputModel model)
        {
            var updatedHospital = await _residenceHospitalRepository.UpdateHospitalAsync(id, model);
            if (updatedHospital == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteHospital(int id)
        {
            var deleted = await _residenceHospitalRepository.DeleteHospitalAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
