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
    public interface IInsuranceRepository
    {
        Task<ServiceResponse<List<InsuranceOutputModel>>> GetAllInsurancesAsync();
        Task<ServiceResponse<InsuranceOutputModel>> GetInsuranceByIdAsync(int id);
        Task<ServiceResponse<InsuranceOutputModel>> AddInsuranceAsync(InsuranceInputModel inputModel);
        Task<ServiceResponse<InsuranceOutputModel>> UpdateInsuranceAsync(int id, InsuranceInputModel inputModel);
        Task<ServiceResponse<bool>> DeleteInsuranceAsync(int id);
    }

}
