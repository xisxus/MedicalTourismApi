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
    public class FollowUpRepository : IFollowUpRepository
    {
        private readonly AppDbContext _context;

        public FollowUpRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FollowUpOutputModel>>> GetAllFollowUpsAsync()
        {
            var followUps = await _context.FollowUps
                .Include(f => f.Patient)
                .Select(f => new FollowUpOutputModel
                {
                    FollowUpID = f.FollowUpID,
                    FollowUpDate = f.FollowUpDate,
                    Notes = f.Notes,
                    CreatedAt = f.CreatedAt,
                    UpdatedAt = f.UpdatedAt,
                    PatientID = f.PatientID,
                    PatientName = f.Patient.Name,
                    PatientPhotoUrl = f.Patient.PhotoUrl
                }).ToListAsync();

            return new ServiceResponse<List<FollowUpOutputModel>>(followUps);
        }

        public async Task<ServiceResponse<FollowUpOutputModel>> GetFollowUpByIdAsync(int id)
        {
            var followUp = await _context.FollowUps
                .Include(f => f.Patient)
                .Where(f => f.FollowUpID == id)
                .Select(f => new FollowUpOutputModel
                {
                    FollowUpID = f.FollowUpID,
                    FollowUpDate = f.FollowUpDate,
                    Notes = f.Notes,
                    CreatedAt = f.CreatedAt,
                    UpdatedAt = f.UpdatedAt,
                    PatientID = f.PatientID,
                    PatientName = f.Patient.Name,
                    PatientPhotoUrl = f.Patient.PhotoUrl
                }).FirstOrDefaultAsync();

            return new ServiceResponse<FollowUpOutputModel>(followUp);
        }

        public async Task<ServiceResponse<FollowUpOutputModel>> AddFollowUpAsync(FollowUpInputModel inputModel)
        {
            var followUp = new FollowUp
            {
                PatientID = inputModel.PatientID,
                FollowUpDate = inputModel.FollowUpDate,
                Notes = inputModel.Notes,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.FollowUps.Add(followUp);
            await _context.SaveChangesAsync();

            return await GetFollowUpByIdAsync(followUp.FollowUpID);
        }

        public async Task<ServiceResponse<FollowUpOutputModel>> UpdateFollowUpAsync(int id, FollowUpInputModel inputModel)
        {
            var followUp = await _context.FollowUps.FindAsync(id);
            if (followUp == null) return new ServiceResponse<FollowUpOutputModel>(null, false, "FollowUp not found");

            followUp.FollowUpDate = inputModel.FollowUpDate;
            followUp.Notes = inputModel.Notes;
            followUp.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return await GetFollowUpByIdAsync(followUp.FollowUpID);
        }

        public async Task<ServiceResponse<bool>> DeleteFollowUpAsync(int id)
        {
            var followUp = await _context.FollowUps.FindAsync(id);
            if (followUp == null) return new ServiceResponse<bool>(false, false, "FollowUp not found");

            _context.FollowUps.Remove(followUp);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>(true);
        }
    }

}
