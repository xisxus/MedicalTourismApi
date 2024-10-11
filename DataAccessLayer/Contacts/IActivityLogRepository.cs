using DataAccessLayer.DTOs.InputModel;
using DataAccessLayer.DTOs.OutputModel;
using DataAccessLayer.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contacts
{
    public interface IActivityLogRepository
    {
        Task<ServiceResponse<List<ActivityLogOutputModel>>> GetAllActivityLogsAsync();
        Task<ServiceResponse<ActivityLogOutputModel>> GetActivityLogByIdAsync(int id);
        Task<ServiceResponse<ActivityLogOutputModel>> AddActivityLogAsync(ActivityLogInputModel inputModel);
        Task<ServiceResponse<ActivityLogOutputModel>> AddActivityLogForPatientAsync(int patientId, ActivityLogInputModel inputModel);
        Task<ServiceResponse<ActivityLogOutputModel>> UpdateActivityLogAsync(int id, ActivityLogInputModel inputModel);
        Task<ServiceResponse<bool>> DeleteActivityLogAsync(int id);
        Task<ServiceResponse<List<ActivityLogOutputModel>>> GetActivityLogsByPatientIdAsync(int patientId);
    }

}
