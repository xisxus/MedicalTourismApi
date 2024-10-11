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
    public interface ICommissionAgentRepository
    {
        Task<ServiceResponse<List<CommissionAgentOutputModel>>> GetAllAgentsAsync();
        Task<ServiceResponse<CommissionAgentOutputModel>> GetAgentByIdAsync(int id);
        Task<ServiceResponse<CommissionAgentOutputModel>> AddAgentAsync(CommissionAgentInputModel inputModel);
        Task<ServiceResponse<CommissionAgentOutputModel>> UpdateAgentAsync(int id, CommissionAgentInputModel inputModel);
        Task<ServiceResponse<bool>> DeleteAgentAsync(int id);
    }

}
