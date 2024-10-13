using DataAccessLayer.Contacts;
using DataAccessLayer.Data;
using DataAccessLayer.DTOs.InputModels;
using DataAccessLayer.DTOs.OutputModels;
using DataAccessLayer.Entites.HospitalRelated;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class ResidenceHospitalRepository : IResidenceHospitalRepository
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ResidenceHospitalRepository(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment; // Inject IWebHostEnvironment
        }

        public async Task<IEnumerable<ResidenceHospitalOutputModel>> GetAllHospitalsAsync()
        {
            return await _context.ResidenceHospitals
                .Select(h => new ResidenceHospitalOutputModel
                {
                    ResidenceHospitalId = h.ResidenceHospitalId,
                    HospitalName = h.HospitalName,
                    Address = h.Address,
                    City = h.City,
                    Country = h.Country,
                    Email = h.Email,
                    Phone = h.Phone,
                    PhotoUrl = h.PhotoUrl,
                    Logo = h.Logo,
                    CreatedAt = h.CreatedAt,
                    UpdatedAt = h.UpdatedAt,
                    ResidenceDoctors = h.ResidenceDoctors.Select(d => new ResidenceDoctorOutputModel
                    {
                    
                        DoctorName = d.DoctorName
                    }).ToList(),
                    TreatmentsPlans = h.TreatmentsPlans.Select(t => new TreatmentPlanOutputModels
                    {
                        TreatmentPlanId = t.TreatmentPlanID,
                     
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<ResidenceHospitalOutputModel> GetHospitalByIdAsync(int id)
        {
            var hospital = await _context.ResidenceHospitals
                .Include(h => h.ResidenceDoctors)
                .Include(h => h.TreatmentsPlans)
                .FirstOrDefaultAsync(h => h.ResidenceHospitalId == id);

            if (hospital == null) return null;

            return new ResidenceHospitalOutputModel
            {
                ResidenceHospitalId = hospital.ResidenceHospitalId,
                HospitalName = hospital.HospitalName,
                Address = hospital.Address,
                City = hospital.City,
                Country = hospital.Country,
                Email = hospital.Email,
                Phone = hospital.Phone,
                PhotoUrl = hospital.PhotoUrl,
                Logo = hospital.Logo,
                CreatedAt = hospital.CreatedAt,
                UpdatedAt = hospital.UpdatedAt,
                ResidenceDoctors = hospital.ResidenceDoctors.Select(d => new ResidenceDoctorOutputModel
                {
                    
                    DoctorName = d.DoctorName
                }).ToList(),
                TreatmentsPlans = hospital.TreatmentsPlans.Select(t => new TreatmentPlanOutputModels
                {
                    TreatmentPlanId = t.TreatmentPlanID,
                    
                }).ToList()
            };
        }

        public async Task<ResidenceHospital> AddHospitalAsync(ResidenceHospitalInputModel model)
        {
            var hospital = new ResidenceHospital
            {
                HospitalName = model.HospitalName,
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                Email = model.Email,
                Phone = model.Phone,
                PhotoUrl = await SaveFileAsync(model.Photo),
                Logo = await SaveFileAsync(model.Logo),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.ResidenceHospitals.Add(hospital);
            await _context.SaveChangesAsync();

            return hospital;
        }

        public async Task<ResidenceHospital> UpdateHospitalAsync(int id, ResidenceHospitalInputModel model)
        {
            var hospital = await _context.ResidenceHospitals.FindAsync(id);
            if (hospital == null) return null;

            hospital.HospitalName = model.HospitalName;
            hospital.Address = model.Address;
            hospital.City = model.City;
            hospital.Country = model.Country;
            hospital.Email = model.Email;
            hospital.Phone = model.Phone;
            hospital.PhotoUrl = await SaveFileAsync(model.Photo);
            hospital.Logo = await SaveFileAsync(model.Logo);
            hospital.UpdatedAt = DateTime.Now;

            _context.ResidenceHospitals.Update(hospital);
            await _context.SaveChangesAsync();

            return hospital;
        }

        public async Task<bool> DeleteHospitalAsync(int id)
        {
            var hospital = await _context.ResidenceHospitals.FindAsync(id);
            if (hospital == null) return false;

            _context.ResidenceHospitals.Remove(hospital);
            await _context.SaveChangesAsync();

            return true;
        }

        private async Task<string> SaveFileAsync(IFormFile file)
        {
            if (file == null) return null;

            // Use IWebHostEnvironment to get the wwwroot folder path
            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

            // Ensure the directory exists
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Create the file path
            var filePath = Path.Combine(uploadPath, file.FileName);

            // Save the file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return the relative path for the database
            return Path.Combine("uploads", file.FileName);
        }
    }


}
