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
    public class HospitalFacilitiesRepository : IHospitalFacilitiesRepository
    {
        private readonly AppDbContext _context;

        public HospitalFacilitiesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HospitalFacilitiesOutModel>> GetAllHospitalFacilitiesAsync()
        {
            return await _context.HospitalFacilities
                .Include(hf => hf.Facilities)
                .Include(hf => hf.Hospital)
                .Select(hf => new HospitalFacilitiesOutModel
                {
                    HospitalFacilitiesId = hf.HospitalFacilitiesId,
                    FacilitiesId = hf.FacilitiesId,
                    FacilitiesDescription = hf.Facilities.FacilitiesDescription,
                    HospitalID = hf.HospitalID,
                    HospitalName = hf.Hospital.HospitalName,
                    CreatedAt = hf.CreatedAt,
                    UpdatedAt = hf.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<HospitalFacilitiesOutModel> GetHospitalFacilitiesByIdAsync(int id)
        {
            var hospitalFacility = await _context.HospitalFacilities
                .Include(hf => hf.Facilities)
                .Include(hf => hf.Hospital)
                .FirstOrDefaultAsync(hf => hf.HospitalFacilitiesId == id);

            if (hospitalFacility == null)
            {
                return null;
            }

            return new HospitalFacilitiesOutModel
            {
                HospitalFacilitiesId = hospitalFacility.HospitalFacilitiesId,
                FacilitiesId = hospitalFacility.FacilitiesId,
                FacilitiesDescription = hospitalFacility.Facilities.FacilitiesDescription,
                HospitalID = hospitalFacility.HospitalID,
                HospitalName = hospitalFacility.Hospital.HospitalName,
                CreatedAt = hospitalFacility.CreatedAt,
                UpdatedAt = hospitalFacility.UpdatedAt
            };
        }

        public async Task<HospitalFacilitiesOutModel> CreateHospitalFacilitiesAsync(HospitalFacilitiesInModel model)
        {
            var newHospitalFacility = new HospitalFacilities
            {
                FacilitiesId = model.FacilitiesId,
                HospitalID = model.HospitalID,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.HospitalFacilities.Add(newHospitalFacility);
            await _context.SaveChangesAsync();

            return await GetHospitalFacilitiesByIdAsync(newHospitalFacility.HospitalFacilitiesId);
        }

        public async Task<HospitalFacilitiesOutModel> UpdateHospitalFacilitiesAsync(int id, HospitalFacilitiesInModel model)
        {
            var existingHospitalFacility = await _context.HospitalFacilities.FindAsync(id);

            if (existingHospitalFacility == null)
            {
                return null;
            }

            existingHospitalFacility.FacilitiesId = model.FacilitiesId;
            existingHospitalFacility.HospitalID = model.HospitalID;
            existingHospitalFacility.UpdatedAt = DateTime.UtcNow;

            _context.HospitalFacilities.Update(existingHospitalFacility);
            await _context.SaveChangesAsync();

            return await GetHospitalFacilitiesByIdAsync(id);
        }

        public async Task<bool> DeleteHospitalFacilitiesAsync(int id)
        {
            var hospitalFacility = await _context.HospitalFacilities.FindAsync(id);

            if (hospitalFacility == null)
            {
                return false;
            }

            _context.HospitalFacilities.Remove(hospitalFacility);
            await _context.SaveChangesAsync();

            return true;
        }
    }

}
