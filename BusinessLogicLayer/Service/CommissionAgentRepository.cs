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
    public class CommissionAgentRepository : ICommissionAgentRepository
    {
        private readonly AppDbContext _context;

        public CommissionAgentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CommissionAgentOutputModel>>> GetAllAgentsAsync()
        {
            var agents = await _context.CommissionAgents
                .Select(a => new CommissionAgentOutputModel
                {
                    AgentID = a.AgentID,
                    FullName = a.FirstName + " " + a.LastName,
                    UserID = a.UserID,
                    CommissionRate = a.CommissionRate,
                    TotalCommissionEarned = a.TotalCommissionEarned,
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt
                }).ToListAsync();

            return new ServiceResponse<List<CommissionAgentOutputModel>>(agents);
        }

        public async Task<ServiceResponse<CommissionAgentOutputModel>> GetAgentByIdAsync(int id)
        {
            var agent = await _context.CommissionAgents
                .Where(a => a.AgentID == id)
                .Select(a => new CommissionAgentOutputModel
                {
                    AgentID = a.AgentID,
                    FullName = a.FirstName + " " + a.LastName,
                    UserID = a.UserID,
                    CommissionRate = a.CommissionRate,
                    TotalCommissionEarned = a.TotalCommissionEarned,
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt
                }).FirstOrDefaultAsync();

            return new ServiceResponse<CommissionAgentOutputModel>(agent);
        }

        public async Task<ServiceResponse<CommissionAgentOutputModel>> AddAgentAsync(CommissionAgentInputModel inputModel)
        {
            var agent = new CommissionAgent
            {
                UserID = inputModel.UserID,
                FirstName = inputModel.FirstName,
                LastName = inputModel.LastName,
                CommissionRate = inputModel.CommissionRate,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.CommissionAgents.Add(agent);
            await _context.SaveChangesAsync();

            return await GetAgentByIdAsync(agent.AgentID);
        }

        public async Task<ServiceResponse<CommissionAgentOutputModel>> UpdateAgentAsync(int id, CommissionAgentInputModel inputModel)
        {
            var agent = await _context.CommissionAgents.FindAsync(id);
            if (agent == null) return new ServiceResponse<CommissionAgentOutputModel>(null, false, "Agent not found");

            agent.FirstName = inputModel.FirstName;
            agent.LastName = inputModel.LastName;
            agent.CommissionRate = inputModel.CommissionRate;
            agent.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return await GetAgentByIdAsync(agent.AgentID);
        }

        public async Task<ServiceResponse<bool>> DeleteAgentAsync(int id)
        {
            var agent = await _context.CommissionAgents.FindAsync(id);
            if (agent == null) return new ServiceResponse<bool>(false, false, "Agent not found");

            _context.CommissionAgents.Remove(agent);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>(true);
        }
    }

}
