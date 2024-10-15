using DataAccessLayer.Entites.HospitalRelated;
using DataAccessLayer.Entites.PatientRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entites.TreatmentAndSurgery
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        // TODO: DoctorId needed
        public string Description { get; set; }
        public string AppointmentFile { get; set; }

        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        public int HospitalID { get; set; }
        public Hospital Hospital { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated


    }
}
