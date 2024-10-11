using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.DTOs.InputModel;
using DataAccessLayer.DTOs.OutputModel;
using DataAccessLayer.DTOs.Response;
using DataAccessLayer.Entites.LogAndComplain;
using Microsoft.EntityFrameworkCore;

public class ActivityLogRepository : IActivityLogRepository
{
    private readonly AppDbContext _context;

    public ActivityLogRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<ActivityLogOutputModel>>> GetAllActivityLogsAsync()
    {
        var activityLogs = await _context.ActivityLogs
            .Select(al => new ActivityLogOutputModel
            {
                ActivityLogID = al.ActivityLogID,
                PatientID = al.PatientID,
                ActivityType = al.ActivityType,
                ActivityDate = al.ActivityDate,
                Description = al.Description,
                CreatedAt = al.CreatedAt,
                UpdatedAt = al.UpdatedAt,
                PatientName = al.Patient.Name,
                PatientAge = al.Patient.Age
            }).ToListAsync();

        return new ServiceResponse<List<ActivityLogOutputModel>>(activityLogs);
    }

    public async Task<ServiceResponse<ActivityLogOutputModel>> GetActivityLogByIdAsync(int id)
    {
        var activityLog = await _context.ActivityLogs
            .Where(al => al.ActivityLogID == id)
            .Select(al => new ActivityLogOutputModel
            {
                ActivityLogID = al.ActivityLogID,
                PatientID = al.PatientID,
                ActivityType = al.ActivityType,
                ActivityDate = al.ActivityDate,
                Description = al.Description,
                CreatedAt = al.CreatedAt,
                UpdatedAt = al.UpdatedAt,
                PatientName = al.Patient.Name,
                PatientAge = al.Patient.Age
            }).FirstOrDefaultAsync();

        if (activityLog == null)
        {
            return new ServiceResponse<ActivityLogOutputModel>
            {
                Success = false,
                Message = "ActivityLog not found."
            };
        }

        return new ServiceResponse<ActivityLogOutputModel>(activityLog);
    }

    public async Task<ServiceResponse<ActivityLogOutputModel>> AddActivityLogAsync(ActivityLogInputModel inputModel)
    {
        var activityLog = new ActivityLog
        {
            PatientID = inputModel.PatientID,
            ActivityType = inputModel.ActivityType,
            ActivityDate = inputModel.ActivityDate,
            Description = inputModel.Description,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        await _context.ActivityLogs.AddAsync(activityLog);
        await _context.SaveChangesAsync();

        return await GetActivityLogByIdAsync(activityLog.ActivityLogID);
    }

    public async Task<ServiceResponse<ActivityLogOutputModel>> AddActivityLogForPatientAsync(int patientId, ActivityLogInputModel inputModel)
    {
        // Here you can add additional logic to check if the patient exists

        var activityLog = new ActivityLog
        {
            PatientID = patientId,
            ActivityType = inputModel.ActivityType,
            ActivityDate = inputModel.ActivityDate,
            Description = inputModel.Description,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        await _context.ActivityLogs.AddAsync(activityLog);
        await _context.SaveChangesAsync();

        return await GetActivityLogByIdAsync(activityLog.ActivityLogID);
    }

    public async Task<ServiceResponse<ActivityLogOutputModel>> UpdateActivityLogAsync(int id, ActivityLogInputModel inputModel)
    {
        var activityLog = await _context.ActivityLogs.FindAsync(id);
        if (activityLog == null)
        {
            return new ServiceResponse<ActivityLogOutputModel>
            {
                Success = false,
                Message = "ActivityLog not found."
            };
        }

        activityLog.ActivityType = inputModel.ActivityType;
        activityLog.ActivityDate = inputModel.ActivityDate;
        activityLog.Description = inputModel.Description;
        activityLog.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();

        return await GetActivityLogByIdAsync(activityLog.ActivityLogID);
    }

    public async Task<ServiceResponse<bool>> DeleteActivityLogAsync(int id)
    {
        var activityLog = await _context.ActivityLogs.FindAsync(id);
        if (activityLog == null)
        {
            return new ServiceResponse<bool>
            {
                Success = false,
                Message = "ActivityLog not found."
            };
        }

        _context.ActivityLogs.Remove(activityLog);
        await _context.SaveChangesAsync();
        return new ServiceResponse<bool> { Data = true };
    }

    public async Task<ServiceResponse<List<ActivityLogOutputModel>>> GetActivityLogsByPatientIdAsync(int patientId)
    {
        var activityLogs = await _context.ActivityLogs
            .Where(al => al.PatientID == patientId)
            .Select(al => new ActivityLogOutputModel
            {
                ActivityLogID = al.ActivityLogID,
                PatientID = al.PatientID,
                ActivityType = al.ActivityType,
                ActivityDate = al.ActivityDate,
                Description = al.Description,
                CreatedAt = al.CreatedAt,
                UpdatedAt = al.UpdatedAt,
                PatientName = al.Patient.Name,
                PatientAge = al.Patient.Age
            }).ToListAsync();

        return new ServiceResponse<List<ActivityLogOutputModel>>(activityLogs);
    }
}
