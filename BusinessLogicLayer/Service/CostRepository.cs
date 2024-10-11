using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.DTOs.InputModel;
using DataAccessLayer.DTOs.OutputModel;
using DataAccessLayer.DTOs.Response;
using DataAccessLayer.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class CostRepository : ICostRepository
    {
        private readonly AppDbContext _context;

        public CostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CostOutputModel>>> GetAllCostsAsync()
        {
            var costs = await _context.Costs.Select(c => new CostOutputModel
            {
                CostID = c.CostID,
                PatientID = c.PatientID,
                ServiceType = c.ServiceType,
                Amount = c.Amount,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            }).ToListAsync();

            return new ServiceResponse<List<CostOutputModel>>(costs);
        }

        public async Task<ServiceResponse<CostOutputModel>> GetCostByIdAsync(int id)
        {
            var cost = await _context.Costs
                .Where(c => c.CostID == id)
                .Select(c => new CostOutputModel
                {
                    CostID = c.CostID,
                    PatientID = c.PatientID,
                    ServiceType = c.ServiceType,
                    Amount = c.Amount,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                }).FirstOrDefaultAsync();

            return new ServiceResponse<CostOutputModel>(cost);
        }

        public async Task<ServiceResponse<CostOutputModel>> AddCostAsync(CostInputModel inputModel)
        {
            var cost = new Cost
            {
                PatientID = inputModel.PatientID,
                ServiceType = inputModel.ServiceType,
                Amount = inputModel.Amount,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Costs.Add(cost);
            await _context.SaveChangesAsync();

            return await GetCostByIdAsync(cost.CostID);
        }

        public async Task<ServiceResponse<CostOutputModel>> UpdateCostAsync(int id, CostInputModel inputModel)
        {
            var cost = await _context.Costs.FindAsync(id);
            if (cost == null) return new ServiceResponse<CostOutputModel>(null, false, "Cost not found");

            cost.PatientID = inputModel.PatientID;
            cost.ServiceType = inputModel.ServiceType;
            cost.Amount = inputModel.Amount;
            cost.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return await GetCostByIdAsync(cost.CostID);
        }

        public async Task<ServiceResponse<bool>> DeleteCostAsync(int id)
        {
            var cost = await _context.Costs.FindAsync(id);
            if (cost == null) return new ServiceResponse<bool>(false, false, "Cost not found");

            _context.Costs.Remove(cost);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>(true);
        }
    }

}
