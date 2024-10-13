using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.Entites.HospitalRelated;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly AppDbContext _context;

        public HospitalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hospital>> GetAllHospitalsAsync()
        {
            return await _context.Hospitals
                .Include(h => h.Appointments)
                .Include(h => h.HospitalFacilities)
                .Include(h => h.Doctors)
                .Include(h => h.TreatmentsPlans)
                .ToListAsync();
        }

        public async Task<Hospital> GetHospitalByIdAsync(int id)
        {
            return await _context.Hospitals
                .Include(h => h.Appointments)
                .Include(h => h.HospitalFacilities)
                .Include(h => h.Doctors)
                .Include(h => h.TreatmentsPlans)
                .FirstOrDefaultAsync(h => h.HospitalID == id);
        }

        public async Task AddHospitalAsync(Hospital hospital)
        {
            await _context.Hospitals.AddAsync(hospital);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHospitalAsync(Hospital hospital)
        {
            _context.Hospitals.Update(hospital);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHospitalAsync(int id)
        {
            var hospital = await _context.Hospitals.FindAsync(id);
            if (hospital != null)
            {
                _context.Hospitals.Remove(hospital);
                await _context.SaveChangesAsync();
            }
        }
    }

}
