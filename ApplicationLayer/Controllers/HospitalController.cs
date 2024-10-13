using DataAccessLayer.Contacts;
using DataAccessLayer.DTOs.InputModels;
using DataAccessLayer.DTOs.OutputModels;
using DataAccessLayer.Entites.HospitalRelated;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HospitalController(IHospitalRepository hospitalRepository, IWebHostEnvironment webHostEnvironment)
        {
            _hospitalRepository = hospitalRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("get")]
        //public async Task<IActionResult> GetHospitals()
        //{
        //    var hospitals = await _hospitalRepository.GetAllHospitalsAsync();
        //    var result = hospitals.Select(h => new HospitalOutputModel
        //    {
        //        HospitalID = h.HospitalID,
        //        HospitalName = h.HospitalName,
        //        Address = h.Address,
        //        City = h.City,
        //        Country = h.Country,
        //        Email = h.Email,
        //        Phone = h.Phone,
        //        PhotoUrl = h.PhotoUrl,
        //        Logo = h.Logo,
        //        Appointments = h.Appointments.Select(a => new AppointmentOutputModel
        //        {
        //            AppointmentID = a.AppointmentID,
        //            AppointmentDate = a.AppointmentDate,
        //            // Map other properties as needed
        //        }).ToList(),
        //        HospitalFacilities = h.HospitalFacilities.Select(f => new HospitalFacilitiesOutputModels
        //        {
        //            HospitalFacilitiesId = f.HospitalFacilitiesId,
        //            FacilityName = f.Facilities.FacilitiesDescription, // Assuming Facilities is a navigation property
        //                                                               // Map other properties as needed
        //        }).ToList(),
        //        Doctors = h.Doctors.Select(d => new DoctorOutputModel
        //        {
        //            DoctorID = d.DoctorId,
        //            DoctorName = d.DoctorName,
        //            // Map other properties as needed
        //        }).ToList(),
        //        TreatmentPlans = h.TreatmentsPlans.Select(tp => new TreatmentPlanOutputModel
        //        {
        //            TreatmentPlanID = tp.TreatmentPlanID,

        //            // Map other properties as needed
        //        }).ToList(),
        //        CreatedAt = h.CreatedAt,
        //        UpdatedAt = h.UpdatedAt
        //    });

        //    return Ok(result);
        //}

   
        public async Task<IActionResult> GetHospitals()
        {
            try
            {
                var hospitals = await _hospitalRepository.GetAllHospitalsAsync();
                if (hospitals == null || !hospitals.Any())
                {
                    return NotFound("No hospitals found.");
                }

                var result = hospitals.Select(h => new HospitalOutputModel
                {
                    HospitalID = h.HospitalID,
                    HospitalName = h.HospitalName,
                    Address = h.Address,
                    City = h.City,
                    Country = h.Country,
                    Email = h.Email,
                    Phone = h.Phone,
                    PhotoUrl = h.PhotoUrl,
                    Logo = h.Logo,
                    Appointments = h.Appointments.Select(a => new AppointmentOutputModel
                    {
                        AppointmentID = a.AppointmentID,
                        AppointmentDate = a.AppointmentDate,
                    }).ToList(),
                    HospitalFacilities = h.HospitalFacilities.Select(f => new HospitalFacilitiesOutputModels
                    {
                        HospitalFacilitiesId = f.HospitalFacilitiesId,
                        FacilityDescription = f.Facilities != null ? f.Facilities.FacilitiesDescription : "No facility description available",
                    }).ToList(),

                    Doctors = h.Doctors.Select(d => new DoctorOutputModel
                    {
                        DoctorID = d.DoctorId,
                        DoctorName = d.DoctorName,
                    }).ToList(),
                    TreatmentPlans = h.TreatmentsPlans.Select(tp => new TreatmentPlanOutputModel
                    {
                        TreatmentPlanID = tp.TreatmentPlanID,
                    }).ToList(),
                    CreatedAt = h.CreatedAt,
                    UpdatedAt = h.UpdatedAt
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving hospitals: " + ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetHospital(int id)
        {
            var hospital = await _hospitalRepository.GetHospitalByIdAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }

            var result = new HospitalOutputModel
            {
                HospitalID = hospital.HospitalID,
                HospitalName = hospital.HospitalName,
                Address = hospital.Address,
                City = hospital.City,
                Country = hospital.Country,
                Email = hospital.Email,
                Phone = hospital.Phone,
                PhotoUrl = hospital.PhotoUrl,
                Logo = hospital.Logo,
                Appointments = hospital.Appointments.Select(a => new AppointmentOutputModel
                {
                    AppointmentID = a.AppointmentID,
                    AppointmentDate = a.AppointmentDate,
                    // Map other properties as needed
                }).ToList(),
                HospitalFacilities = hospital.HospitalFacilities.Select(f => new HospitalFacilitiesOutputModels
                {
                    HospitalFacilitiesId = f.HospitalFacilitiesId,
                    FacilityDescription = f.Facilities.FacilitiesDescription,
                    // Map other properties as needed
                }).ToList(),
                Doctors = hospital.Doctors.Select(d => new DoctorOutputModel
                {
                    DoctorID = d.DoctorId,
                    DoctorName = d.DoctorName,
                    // Map other properties as needed
                }).ToList(),
                TreatmentPlans = hospital.TreatmentsPlans.Select(tp => new TreatmentPlanOutputModel
                {
                    TreatmentPlanID = tp.TreatmentPlanID,
                   
                    // Map other properties as needed
                }).ToList(),
                CreatedAt = hospital.CreatedAt,
                UpdatedAt = hospital.UpdatedAt
            };

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateHospital([FromForm] HospitalInputModel inputModel)
        {
            var hospital = new Hospital
            {
                HospitalName = inputModel.HospitalName,
                Address = inputModel.Address,
                City = inputModel.City,
                Country = inputModel.Country,
                Email = inputModel.Email,
                Phone = inputModel.Phone,
                PhotoUrl = await SaveFileAsync(inputModel.Photo), // Implement SaveFileAsync method
                Logo = await SaveFileAsync(inputModel.Logo), // Implement SaveFileAsync method
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _hospitalRepository.AddHospitalAsync(hospital);
            return CreatedAtAction(nameof(GetHospital), new { id = hospital.HospitalID }, hospital);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdateHospital(int id, [FromForm] HospitalInputModel inputModel)
        {
            var hospital = await _hospitalRepository.GetHospitalByIdAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }

            hospital.HospitalName = inputModel.HospitalName;
            hospital.Address = inputModel.Address;
            hospital.City = inputModel.City;
            hospital.Country = inputModel.Country;
            hospital.Email = inputModel.Email;
            hospital.Phone = inputModel.Phone;

            // Update file URLs if new files are uploaded
            if (inputModel.Photo != null)
            {
                hospital.PhotoUrl = await SaveFileAsync(inputModel.Photo); // Implement SaveFileAsync method
            }
            if (inputModel.Logo != null)
            {
                hospital.Logo = await SaveFileAsync(inputModel.Logo); // Implement SaveFileAsync method
            }

            hospital.UpdatedAt = DateTime.Now;

            await _hospitalRepository.UpdateHospitalAsync(hospital);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteHospital(int id)
        {
            await _hospitalRepository.DeleteHospitalAsync(id);
            return NoContent();
        }

        // Method to save uploaded files
        private async Task<string> SaveFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads"); // Use IWebHostEnvironment to get the root path
            Directory.CreateDirectory(uploadsFolder); // Ensure the folder exists

            var filePath = Path.Combine(uploadsFolder, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/uploads/{file.FileName}"; // Return the URL path
        }
    }
}
