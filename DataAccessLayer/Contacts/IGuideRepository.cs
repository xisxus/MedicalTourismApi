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
    public interface IGuideRepository
    {
        Task<ServiceResponse<List<GuideOutputModel>>> GetAllGuidesAsync();
        Task<ServiceResponse<GuideOutputModel>> GetGuideByIdAsync(int id);
        Task<ServiceResponse<GuideOutputModel>> AddGuideAsync(GuideInputModel inputModel);
        Task<ServiceResponse<GuideOutputModel>> UpdateGuideAsync(int id, GuideInputModel inputModel);
        Task<ServiceResponse<bool>> DeleteGuideAsync(int id);
    }
}
