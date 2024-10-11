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
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly AppDbContext _context;

        public InsuranceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<InsuranceOutputModel>>> GetAllInsurancesAsync()
        {
            var insurances = await _context.Insurances
                .Include(i => i.Patient)
                .Select(i => new InsuranceOutputModel
                {
                    InsuranceID = i.InsuranceID,
                    InsuranceProvider = i.InsuranceProvider,
                    PolicyNumber = i.PolicyNumber,
                    CreatedAt = i.CreatedAt,
                    UpdatedAt = i.UpdatedAt,
                    PatientID = i.PatientID,
                    PatientName = i.Patient.Name,
                    PatientPhotoUrl = i.Patient.PhotoUrl
                }).ToListAsync();

            return new ServiceResponse<List<InsuranceOutputModel>>(insurances);
        }

        public async Task<ServiceResponse<InsuranceOutputModel>> GetInsuranceByIdAsync(int id)
        {
            var insurance = await _context.Insurances
                .Include(i => i.Patient)
                .Where(i => i.InsuranceID == id)
                .Select(i => new InsuranceOutputModel
                {
                    InsuranceID = i.InsuranceID,
                    InsuranceProvider = i.InsuranceProvider,
                    PolicyNumber = i.PolicyNumber,
                    CreatedAt = i.CreatedAt,
                    UpdatedAt = i.UpdatedAt,
                    PatientID = i.PatientID,
                    PatientName = i.Patient.Name,
                    PatientPhotoUrl = i.Patient.PhotoUrl
                }).FirstOrDefaultAsync();

            return new ServiceResponse<InsuranceOutputModel>(insurance);
        }

        public async Task<ServiceResponse<InsuranceOutputModel>> AddInsuranceAsync(InsuranceInputModel inputModel)
        {
            var insurance = new Insurance
            {
                InsuranceProvider = inputModel.InsuranceProvider,
                PolicyNumber = inputModel.PolicyNumber,
                PatientID = inputModel.PatientID,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Insurances.Add(insurance);
            await _context.SaveChangesAsync();

            return await GetInsuranceByIdAsync(insurance.InsuranceID);
        }

        public async Task<ServiceResponse<InsuranceOutputModel>> UpdateInsuranceAsync(int id, InsuranceInputModel inputModel)
        {
            var insurance = await _context.Insurances.FindAsync(id);
            if (insurance == null) return new ServiceResponse<InsuranceOutputModel>(null, false, "Insurance not found");

            insurance.InsuranceProvider = inputModel.InsuranceProvider;
            insurance.PolicyNumber = inputModel.PolicyNumber;
            insurance.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return await GetInsuranceByIdAsync(insurance.InsuranceID);
        }

        public async Task<ServiceResponse<bool>> DeleteInsuranceAsync(int id)
        {
            var insurance = await _context.Insurances.FindAsync(id);
            if (insurance == null) return new ServiceResponse<bool>(false, false, "Insurance not found");

            _context.Insurances.Remove(insurance);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>(true);
        }
    }

}
