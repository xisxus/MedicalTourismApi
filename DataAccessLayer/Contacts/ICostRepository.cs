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
    public interface ICostRepository
    {
        Task<ServiceResponse<List<CostOutputModel>>> GetAllCostsAsync();
        Task<ServiceResponse<CostOutputModel>> GetCostByIdAsync(int id);
        Task<ServiceResponse<CostOutputModel>> AddCostAsync(CostInputModel inputModel);
        Task<ServiceResponse<CostOutputModel>> UpdateCostAsync(int id, CostInputModel inputModel);
        Task<ServiceResponse<bool>> DeleteCostAsync(int id);
    }

}
