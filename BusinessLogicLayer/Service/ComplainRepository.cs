using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.DTOs.InputModel;
using DataAccessLayer.DTOs.OutputModel;
using DataAccessLayer.DTOs.Response;
using DataAccessLayer.Entites.LogAndComplain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class ComplainRepository : IComplainRepository
    {
        private readonly AppDbContext _context;

        public ComplainRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ComplainOutputModel>>> GetAllComplainsAsync()
        {
            var complains = await _context.Complains
                .Select(c => new ComplainOutputModel
                {
                    ComplainId = c.ComplainId,
                    ComplainType = c.ComplainType,
                    ComplainDescription = c.ComplainDescription,
                    ComplainStatus = c.ComplainStatus,
                    ComplainDate = c.ComplainDate
                }).ToListAsync();

            return new ServiceResponse<List<ComplainOutputModel>>(complains);
        }

        public async Task<ServiceResponse<ComplainOutputModel>> GetComplainByIdAsync(int id)
        {
            var complain = await _context.Complains
                .Where(c => c.ComplainId == id)
                .Select(c => new ComplainOutputModel
                {
                    ComplainId = c.ComplainId,
                    ComplainType = c.ComplainType,
                    ComplainDescription = c.ComplainDescription,
                    ComplainStatus = c.ComplainStatus,
                    ComplainDate = c.ComplainDate
                }).FirstOrDefaultAsync();

            if (complain == null)
            {
                return new ServiceResponse<ComplainOutputModel>
                {
                    Success = false,
                    Message = "Complain not found."
                };
            }

            return new ServiceResponse<ComplainOutputModel>(complain);
        }

        public async Task<ServiceResponse<ComplainOutputModel>> AddComplainAsync(ComplainInputModel inputModel)
        {
            var complain = new Complain
            {
                ComplainType = inputModel.ComplainType,
                ComplainDescription = inputModel.ComplainDescription,
                ComplainStatus = inputModel.ComplainStatus,
                ComplainDate = DateTime.Now
            };

            await _context.Complains.AddAsync(complain);
            await _context.SaveChangesAsync();

            return await GetComplainByIdAsync(complain.ComplainId);
        }

        public async Task<ServiceResponse<ComplainOutputModel>> UpdateComplainAsync(int id, ComplainInputModel inputModel)
        {
            var complain = await _context.Complains.FindAsync(id);
            if (complain == null)
            {
                return new ServiceResponse<ComplainOutputModel>
                {
                    Success = false,
                    Message = "Complain not found."
                };
            }

            complain.ComplainType = inputModel.ComplainType;
            complain.ComplainDescription = inputModel.ComplainDescription;
            complain.ComplainStatus = inputModel.ComplainStatus;
            complain.ComplainDate = DateTime.Now; // Update date to current time

            await _context.SaveChangesAsync();

            return await GetComplainByIdAsync(complain.ComplainId);
        }

        public async Task<ServiceResponse<bool>> DeleteComplainAsync(int id)
        {
            var complain = await _context.Complains.FindAsync(id);
            if (complain == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "Complain not found."
                };
            }

            _context.Complains.Remove(complain);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }
    }
}
