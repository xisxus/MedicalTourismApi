using DataAccessLayer.DTOs.OutputModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.InputModels
{
    public class ResidenceHospitalInputModel
    {
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile Logo { get; set; }
        public List<ResidenceDoctorInputModel> ResidenceDoctors { get; set; } // List of related doctors
        public List<TreatmentPlanInputModel> TreatmentsPlans { get; set; }   // List of related treatment plans
    }
    public class ResidenceDoctorInputModel
    {
        public int ResidenceDoctorId { get; set; }
        public string DoctorName { get; set; }


    }
    public class TreatmentPlanInputModel
    {
        public int TreatmentPlanId { get; set; }


    }
}
