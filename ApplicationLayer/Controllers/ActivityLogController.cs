using DataAccessLayer.Contacts;
using DataAccessLayer.DTOs.InputModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ActivityLogController : ControllerBase
{
    private readonly IActivityLogRepository _activityLogRepository;

    public ActivityLogController(IActivityLogRepository activityLogRepository)
    {
        _activityLogRepository = activityLogRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllActivityLogs()
    {
        var result = await _activityLogRepository.GetAllActivityLogsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivityLogById(int id)
    {
        var result = await _activityLogRepository.GetActivityLogByIdAsync(id);
        if (!result.Success)
        {
            return NotFound(result.Message);
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddActivityLog([FromBody] ActivityLogInputModel inputModel)
    {
        var result = await _activityLogRepository.AddActivityLogAsync(inputModel);
        return CreatedAtAction(nameof(GetActivityLogById), new { id = result.Data.ActivityLogID }, result);
    }

    [HttpPost("patient/{patientId}")]
    public async Task<IActionResult> AddActivityLogForPatient(int patientId, [FromBody] ActivityLogInputModel inputModel)
    {
        var result = await _activityLogRepository.AddActivityLogForPatientAsync(patientId, inputModel);
        return CreatedAtAction(nameof(GetActivityLogById), new { id = result.Data.ActivityLogID }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateActivityLog(int id, [FromBody] ActivityLogInputModel inputModel)
    {
        var result = await _activityLogRepository.UpdateActivityLogAsync(id, inputModel);
        if (!result.Success)
        {
            return NotFound(result.Message);
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivityLog(int id)
    {
        var result = await _activityLogRepository.DeleteActivityLogAsync(id);
        if (!result.Success)
        {
            return NotFound(result.Message);
        }
        return NoContent(); // Status 204
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetActivityLogsByPatientId(int patientId)
    {
        var result = await _activityLogRepository.GetActivityLogsByPatientIdAsync(patientId);
        return Ok(result);
    }
}

