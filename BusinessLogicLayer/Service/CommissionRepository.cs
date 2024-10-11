using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.DTOs.InputModel;
using DataAccessLayer.DTOs.OutputModel;
using DataAccessLayer.DTOs.Response;
using DataAccessLayer.Entites.CommisionAgent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class CommissionRepository : ICommissionRepository
    {
        private readonly AppDbContext _context;

        public CommissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CommissionOutputModel>>> GetAllCommissionsAsync()
        {
            var commissions = await _context.Commissions
                .Include(c => c.CommissionAgent)
                .Include(c => c.Patient)
                .Select(c => new CommissionOutputModel
                {
                    CommissionID = c.CommissionID,
                    AgentID = c.AgentID,
                    AgentFullName = c.CommissionAgent.FirstName + " " + c.CommissionAgent.LastName,
                    PatientID = c.PatientID,
                    CommissionAmount = c.CommissionAmount,
                    DateEarned = c.DateEarned,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                }).ToListAsync();

            return new ServiceResponse<List<CommissionOutputModel>>(commissions);
        }

        public async Task<ServiceResponse<CommissionOutputModel>> GetCommissionByIdAsync(int id)
        {
            var commission = await _context.Commissions
                .Include(c => c.CommissionAgent)
                .Include(c => c.Patient)
                .Where(c => c.CommissionID == id)
                .Select(c => new CommissionOutputModel
                {
                    CommissionID = c.CommissionID,
                    AgentID = c.AgentID,
                    AgentFullName = c.CommissionAgent.FirstName + " " + c.CommissionAgent.LastName,
                    PatientID = c.PatientID,
                    CommissionAmount = c.CommissionAmount,
                    DateEarned = c.DateEarned,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                }).FirstOrDefaultAsync();

            return new ServiceResponse<CommissionOutputModel>(commission);
        }

        public async Task<ServiceResponse<CommissionOutputModel>> AddCommissionAsync(CommissionInputModel inputModel)
        {
            var commission = new Commission
            {
                AgentID = inputModel.AgentID,
                PatientID = inputModel.PatientID,
                CommissionAmount = inputModel.CommissionAmount,
                DateEarned = inputModel.DateEarned
            };

            _context.Commissions.Add(commission);
            await _context.SaveChangesAsync();

            return await GetCommissionByIdAsync(commission.CommissionID);
        }

        public async Task<ServiceResponse<CommissionOutputModel>> UpdateCommissionAsync(int id, CommissionInputModel inputModel)
        {
            var commission = await _context.Commissions.FindAsync(id);
            if (commission == null) return new ServiceResponse<CommissionOutputModel>(null, false, "Commission not found");

            commission.AgentID = inputModel.AgentID;
            commission.PatientID = inputModel.PatientID;
            commission.CommissionAmount = inputModel.CommissionAmount;
            commission.DateEarned = inputModel.DateEarned;
            commission.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return await GetCommissionByIdAsync(commission.CommissionID);
        }

        public async Task<ServiceResponse<bool>> DeleteCommissionAsync(int id)
        {
            var commission = await _context.Commissions.FindAsync(id);
            if (commission == null) return new ServiceResponse<bool>(false, false, "Commission not found");

            _context.Commissions.Remove(commission);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>(true);
        }
    }

}
