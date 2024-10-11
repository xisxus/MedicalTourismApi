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
    public interface IComplainRepository
    {
        Task<ServiceResponse<List<ComplainOutputModel>>> GetAllComplainsAsync();
        Task<ServiceResponse<ComplainOutputModel>> GetComplainByIdAsync(int id);
        Task<ServiceResponse<ComplainOutputModel>> AddComplainAsync(ComplainInputModel inputModel);
        Task<ServiceResponse<ComplainOutputModel>> UpdateComplainAsync(int id, ComplainInputModel inputModel);
        Task<ServiceResponse<bool>> DeleteComplainAsync(int id);
    }
}
