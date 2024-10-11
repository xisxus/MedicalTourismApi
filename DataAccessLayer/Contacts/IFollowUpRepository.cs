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
    public interface IFollowUpRepository
    {
        Task<ServiceResponse<List<FollowUpOutputModel>>> GetAllFollowUpsAsync();
        Task<ServiceResponse<FollowUpOutputModel>> GetFollowUpByIdAsync(int id);
        Task<ServiceResponse<FollowUpOutputModel>> AddFollowUpAsync(FollowUpInputModel inputModel);
        Task<ServiceResponse<FollowUpOutputModel>> UpdateFollowUpAsync(int id, FollowUpInputModel inputModel);
        Task<ServiceResponse<bool>> DeleteFollowUpAsync(int id);
    }

}
