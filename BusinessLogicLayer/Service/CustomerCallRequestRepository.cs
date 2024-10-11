using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.DTOs.InputModel;
using DataAccessLayer.DTOs.OutputModel;
using DataAccessLayer.DTOs.Response;
using DataAccessLayer.Entites.CustomerSupport;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class CustomerCallRequestRepository : ICustomerCallRequestRepository
    {
        private readonly AppDbContext _context;

        public CustomerCallRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CustomerCallRequestOutputModel>>> GetAllRequestsAsync()
        {
            var requests = await _context.CustomerCallRequests
                .Select(c => new CustomerCallRequestOutputModel
                {
                    CustomerCallRequestID = c.CustomerCallRequestID,
                    Name = c.Name,
                    MobileNo = c.MobileNo,
                    Email = c.Email,
                    Message = c.Message,
                    Status = c.Status,
                    StatusMessage = c.StatusMessage,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                }).ToListAsync();

            return new ServiceResponse<List<CustomerCallRequestOutputModel>>(requests);
        }

        public async Task<ServiceResponse<CustomerCallRequestOutputModel>> GetRequestByIdAsync(int id)
        {
            var request = await _context.CustomerCallRequests
                .Where(c => c.CustomerCallRequestID == id)
                .Select(c => new CustomerCallRequestOutputModel
                {
                    CustomerCallRequestID = c.CustomerCallRequestID,
                    Name = c.Name,
                    MobileNo = c.MobileNo,
                    Email = c.Email,
                    Message = c.Message,
                    Status = c.Status,
                    StatusMessage = c.StatusMessage,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                }).FirstOrDefaultAsync();

            return new ServiceResponse<CustomerCallRequestOutputModel>(request);
        }

        public async Task<ServiceResponse<CustomerCallRequestOutputModel>> AddRequestAsync(CustomerCallRequestInputModel inputModel)
        {
            var request = new CustomerCallRequest
            {
                Name = inputModel.Name,
                MobileNo = inputModel.MobileNo,
                Email = inputModel.Email,
                Message = inputModel.Message,
                Status = inputModel.Status,
                StatusMessage = inputModel.StatusMessage,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.CustomerCallRequests.Add(request);
            await _context.SaveChangesAsync();

            return await GetRequestByIdAsync(request.CustomerCallRequestID);
        }

        public async Task<ServiceResponse<CustomerCallRequestOutputModel>> UpdateRequestAsync(int id, CustomerCallRequestInputModel inputModel)
        {
            var request = await _context.CustomerCallRequests.FindAsync(id);
            if (request == null) return new ServiceResponse<CustomerCallRequestOutputModel>(null, false, "Request not found");

            request.Name = inputModel.Name;
            request.MobileNo = inputModel.MobileNo;
            request.Email = inputModel.Email;
            request.Message = inputModel.Message;
            request.Status = inputModel.Status;
            request.StatusMessage = inputModel.StatusMessage;
            request.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return await GetRequestByIdAsync(request.CustomerCallRequestID);
        }

        public async Task<ServiceResponse<bool>> DeleteRequestAsync(int id)
        {
            var request = await _context.CustomerCallRequests.FindAsync(id);
            if (request == null) return new ServiceResponse<bool>(false, false, "Request not found");

            _context.CustomerCallRequests.Remove(request);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>(true);
        }
    }

}
