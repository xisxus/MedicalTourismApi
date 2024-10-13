using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.OutputModels
{
    public class ResidenceHospitalOutputModel
    {
        public int ResidenceHospitalId { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhotoUrl { get; set; }
        public string Logo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<ResidenceDoctorOutputModel> ResidenceDoctors { get; set; } // List of related doctors
        public List<TreatmentPlanOutputModels> TreatmentsPlans { get; set; }   // List of related treatment plans
    }
    public class ResidenceDoctorOutputModel
    {

        public string DoctorName { get; set; }


    }
    public class TreatmentPlanOutputModels
    {
        public int TreatmentPlanId { get; set; }


    }


}
