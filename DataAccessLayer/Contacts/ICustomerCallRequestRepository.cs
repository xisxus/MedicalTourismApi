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
    public interface ICustomerCallRequestRepository
    {
        Task<ServiceResponse<List<CustomerCallRequestOutputModel>>> GetAllRequestsAsync();
        Task<ServiceResponse<CustomerCallRequestOutputModel>> GetRequestByIdAsync(int id);
        Task<ServiceResponse<CustomerCallRequestOutputModel>> AddRequestAsync(CustomerCallRequestInputModel inputModel);
        Task<ServiceResponse<CustomerCallRequestOutputModel>> UpdateRequestAsync(int id, CustomerCallRequestInputModel inputModel);
        Task<ServiceResponse<bool>> DeleteRequestAsync(int id);
    }

}
