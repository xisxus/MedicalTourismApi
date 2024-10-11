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
    public interface ICommissionRepository
    {
        Task<ServiceResponse<List<CommissionOutputModel>>> GetAllCommissionsAsync();
        Task<ServiceResponse<CommissionOutputModel>> GetCommissionByIdAsync(int id);
        Task<ServiceResponse<CommissionOutputModel>> AddCommissionAsync(CommissionInputModel inputModel);
        Task<ServiceResponse<CommissionOutputModel>> UpdateCommissionAsync(int id, CommissionInputModel inputModel);
        Task<ServiceResponse<bool>> DeleteCommissionAsync(int id);
    }

}
