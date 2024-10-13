using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.DTOs.InputModels;
using DataAccessLayer.DTOs.OutputModels;
using DataAccessLayer.Entites.HospitalRelated;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class FacilitiesRepository : IFacilitiesRepository
    {
        private readonly AppDbContext _context;

        public FacilitiesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FacilitiesOutputModel>> GetAllFacilitiesAsync()
        {
            return await _context.Facilities
                .Include(f => f.HospitalFacilities)
                .ThenInclude(hf => hf.Hospital)
                .Select(f => new FacilitiesOutputModel
                {
                    FacilitiesId = f.FacilitiesId,
                    FacilitiesDescription = f.FacilitiesDescription,
                    HospitalFacilities = f.HospitalFacilities.Select(hf => new HospitalFacilitiesOutputModel
                    {
                        HospitalFacilitiesId = hf.HospitalFacilitiesId,
                        HospitalID = hf.HospitalID,
                        HospitalName = hf.Hospital.HospitalName, // Assuming Hospital has a Name property
                        CreatedAt = hf.CreatedAt,
                        UpdatedAt = hf.UpdatedAt
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<FacilitiesOutputModel> GetFacilitiesByIdAsync(int id)
        {
            var facility = await _context.Facilities
                .Include(f => f.HospitalFacilities)
                .ThenInclude(hf => hf.Hospital)
                .FirstOrDefaultAsync(f => f.FacilitiesId == id);

            if (facility == null) return null;

            return new FacilitiesOutputModel
            {
                FacilitiesId = facility.FacilitiesId,
                FacilitiesDescription = facility.FacilitiesDescription,
                HospitalFacilities = facility.HospitalFacilities.Select(hf => new HospitalFacilitiesOutputModel
                {
                    HospitalFacilitiesId = hf.HospitalFacilitiesId,
                    HospitalID = hf.HospitalID,
                    HospitalName = hf.Hospital.HospitalName, // Assuming Hospital has a Name property
                    CreatedAt = hf.CreatedAt,
                    UpdatedAt = hf.UpdatedAt
                }).ToList()
            };
        }

        public async Task<FacilitiesOutputModel> AddFacilitiesAsync(FacilitiesInputModel inputModel)
        {
            var facility = new Facilities
            {
                FacilitiesDescription = inputModel.FacilitiesDescription,
                HospitalFacilities = inputModel.HospitalFacilities.Select(hf => new HospitalFacilities
                {
                    HospitalID = hf.HospitalID,
                    CreatedAt = hf.CreatedAt,
                    UpdatedAt = hf.UpdatedAt
                }).ToList()
            };

            _context.Facilities.Add(facility);
            await _context.SaveChangesAsync();

            return await GetFacilitiesByIdAsync(facility.FacilitiesId); // Return the newly created facility
        }

        public async Task<FacilitiesOutputModel> UpdateFacilitiesAsync(int id, FacilitiesInputModel inputModel)
        {
            var facility = await _context.Facilities.Include(f => f.HospitalFacilities).FirstOrDefaultAsync(f => f.FacilitiesId == id);

            if (facility == null) return null;

            facility.FacilitiesDescription = inputModel.FacilitiesDescription;

            // Update existing HospitalFacilities
            foreach (var hfInput in inputModel.HospitalFacilities)
            {
                var hospitalFacility = facility.HospitalFacilities.FirstOrDefault(hf => hf.HospitalID == hfInput.HospitalID);
                if (hospitalFacility != null)
                {
                    hospitalFacility.CreatedAt = hfInput.CreatedAt;
                    hospitalFacility.UpdatedAt = hfInput.UpdatedAt;
                }
                else
                {
                    // Add new HospitalFacilities if not already present
                    facility.HospitalFacilities.Add(new HospitalFacilities
                    {
                        HospitalID = hfInput.HospitalID,
                        CreatedAt = hfInput.CreatedAt,
                        UpdatedAt = hfInput.UpdatedAt
                    });
                }
            }

            await _context.SaveChangesAsync();
            return await GetFacilitiesByIdAsync(facility.FacilitiesId);
        }

        public async Task<bool> DeleteFacilitiesAsync(int id)
        {
            var facility = await _context.Facilities.FindAsync(id);
            if (facility == null) return false;

            _context.Facilities.Remove(facility);
            await _context.SaveChangesAsync();

            return true;
        }
    }


}
