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
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _context;

        public FeedbackRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FeedbackOutputModel>>> GetAllFeedbacksAsync()
        {
            var feedbacks = await _context.Feedbacks
                .Include(f => f.Patient)
                .Include(f => f.Hospital)
                .Select(f => new FeedbackOutputModel
                {
                    FeedbackID = f.FeedbackID,
                    Comments = f.Comments,
                    Rating = f.Rating,
                    CreatedAt = f.CreatedAt,
                    UpdatedAt = f.UpdatedAt,
                    PatientID = f.PatientID,
                    PatientName = f.Patient.Name,
                    PatientPhotoUrl = f.Patient.PhotoUrl,
                    HospitalID = f.HospitalID,
                    HospitalName = f.Hospital.HospitalName,
                    HospitalAddress = f.Hospital.Address,
                    HospitalPhotoUrl = f.Hospital.PhotoUrl,
                    HospitalLogo = f.Hospital.Logo
                }).ToListAsync();

            return new ServiceResponse<List<FeedbackOutputModel>>(feedbacks);
        }

        public async Task<ServiceResponse<FeedbackOutputModel>> GetFeedbackByIdAsync(int id)
        {
            var feedback = await _context.Feedbacks
                .Include(f => f.Patient)
                .Include(f => f.Hospital)
                .Where(f => f.FeedbackID == id)
                .Select(f => new FeedbackOutputModel
                {
                    FeedbackID = f.FeedbackID,
                    Comments = f.Comments,
                    Rating = f.Rating,
                    CreatedAt = f.CreatedAt,
                    UpdatedAt = f.UpdatedAt,
                    PatientID = f.PatientID,
                    PatientName = f.Patient.Name,
                    PatientPhotoUrl = f.Patient.PhotoUrl,
                    HospitalID = f.HospitalID,
                    HospitalName = f.Hospital.HospitalName,
                    HospitalAddress = f.Hospital.Address,
                    HospitalPhotoUrl = f.Hospital.PhotoUrl,
                    HospitalLogo = f.Hospital.Logo
                }).FirstOrDefaultAsync();

            return new ServiceResponse<FeedbackOutputModel>(feedback);
        }

        public async Task<ServiceResponse<FeedbackOutputModel>> AddFeedbackAsync(FeedbackInputModel inputModel)
        {
            var feedback = new Feedback
            {
                PatientID = inputModel.PatientID,
                HospitalID = inputModel.HospitalID,
                Comments = inputModel.Comments,
                Rating = inputModel.Rating,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return await GetFeedbackByIdAsync(feedback.FeedbackID);
        }

        public async Task<ServiceResponse<FeedbackOutputModel>> UpdateFeedbackAsync(int id, FeedbackInputModel inputModel)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null) return new ServiceResponse<FeedbackOutputModel>(null, false, "Feedback not found");

            feedback.Comments = inputModel.Comments;
            feedback.Rating = inputModel.Rating;
            feedback.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return await GetFeedbackByIdAsync(feedback.FeedbackID);
        }

        public async Task<ServiceResponse<bool>> DeleteFeedbackAsync(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null) return new ServiceResponse<bool>(false, false, "Feedback not found");

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>(true);
        }
    }

}
