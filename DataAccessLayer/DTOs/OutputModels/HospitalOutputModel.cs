using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.OutputModels
{
    public class HospitalOutputModel
    {
        public int HospitalID { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhotoUrl { get; set; }
        public string Logo { get; set; }

        // List of Appointments
        public List<AppointmentOutputModel> Appointments { get; set; } = new List<AppointmentOutputModel>();

        // List of Hospital Facilities
        public List<HospitalFacilitiesOutputModels> HospitalFacilities { get; set; } = new List<HospitalFacilitiesOutputModels>();

        // List of Doctors
        public List<DoctorOutputModel> Doctors { get; set; } = new List<DoctorOutputModel>();

        // List of Treatment Plans
        public List<TreatmentPlanOutputModel> TreatmentPlans { get; set; } = new List<TreatmentPlanOutputModel>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
    public class AppointmentOutputModel
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        // Add other relevant properties
    }

    public class HospitalFacilitiesOutputModels
    {
        public int HospitalFacilitiesId { get; set; }
        public string FacilityDescription { get; set; }
        // Add other relevant properties
    }

    public class DoctorOutputModel
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        // Add other relevant properties
    }

    public class TreatmentPlanOutputModel
    {
        public int TreatmentPlanID { get; set; }
       
        // Add other relevant properties
    }

}
