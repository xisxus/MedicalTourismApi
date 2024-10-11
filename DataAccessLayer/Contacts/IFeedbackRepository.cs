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
    public interface IFeedbackRepository
    {
        Task<ServiceResponse<List<FeedbackOutputModel>>> GetAllFeedbacksAsync();
        Task<ServiceResponse<FeedbackOutputModel>> GetFeedbackByIdAsync(int id);
        Task<ServiceResponse<FeedbackOutputModel>> AddFeedbackAsync(FeedbackInputModel inputModel);
        Task<ServiceResponse<FeedbackOutputModel>> UpdateFeedbackAsync(int id, FeedbackInputModel inputModel);
        Task<ServiceResponse<bool>> DeleteFeedbackAsync(int id);
    }

}
