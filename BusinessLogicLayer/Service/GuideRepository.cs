using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.DTOs.InputModel;
using DataAccessLayer.DTOs.OutputModel;
using DataAccessLayer.DTOs.Response;
using DataAccessLayer.Entites.GuideRelated;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class GuideRepository : IGuideRepository
    {
        private readonly AppDbContext _context;

        public GuideRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<GuideOutputModel>>> GetAllGuidesAsync()
        {
            var guides = await _context.Guides
                .Select(g => new GuideOutputModel
                {
                    GuideId = g.GuideId,
                    GuidName = g.GuidName,
                    PhoneNo = g.PhoneNo,
                    GuidePhotoUrl = g.GuidePhotoUrl,
                    CreatedAt = g.CreatedAt,
                    UpdatedAt = g.UpdatedAt
                }).ToListAsync();

            return new ServiceResponse<List<GuideOutputModel>>(guides);
        }

        public async Task<ServiceResponse<GuideOutputModel>> GetGuideByIdAsync(int id)
        {
            var guide = await _context.Guides
                .Where(g => g.GuideId == id)
                .Select(g => new GuideOutputModel
                {
                    GuideId = g.GuideId,
                    GuidName = g.GuidName,
                    PhoneNo = g.PhoneNo,
                    GuidePhotoUrl = g.GuidePhotoUrl,
                    CreatedAt = g.CreatedAt,
                    UpdatedAt = g.UpdatedAt
                }).FirstOrDefaultAsync();

            if (guide == null)
            {
                return new ServiceResponse<GuideOutputModel>
                {
                    Success = false,
                    Message = "Guide not found."
                };
            }

            return new ServiceResponse<GuideOutputModel>(guide);
        }

        public async Task<ServiceResponse<GuideOutputModel>> AddGuideAsync(GuideInputModel inputModel)
        {
            var guide = new Guide
            {
                GuidName = inputModel.GuidName,
                PhoneNo = inputModel.PhoneNo,
                GuidePhotoUrl = inputModel.GuidePhotoUrl,
                CreatedAt = DateTime.Now
            };

            await _context.Guides.AddAsync(guide);
            await _context.SaveChangesAsync();

            return await GetGuideByIdAsync(guide.GuideId);
        }

        public async Task<ServiceResponse<GuideOutputModel>> UpdateGuideAsync(int id, GuideInputModel inputModel)
        {
            var guide = await _context.Guides.FindAsync(id);
            if (guide == null)
            {
                return new ServiceResponse<GuideOutputModel>
                {
                    Success = false,
                    Message = "Guide not found."
                };
            }

            guide.GuidName = inputModel.GuidName;
            guide.PhoneNo = inputModel.PhoneNo;
            guide.GuidePhotoUrl = inputModel.GuidePhotoUrl;
            guide.UpdatedAt = DateTime.Now; // Update date to current time

            await _context.SaveChangesAsync();

            return await GetGuideByIdAsync(guide.GuideId);
        }

        public async Task<ServiceResponse<bool>> DeleteGuideAsync(int id)
        {
            var guide = await _context.Guides.FindAsync(id);
            if (guide == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "Guide not found."
                };
            }

            _context.Guides.Remove(guide);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }
    }
}
