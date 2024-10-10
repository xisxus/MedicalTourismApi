using DataAccessLayer.Entites.TicketAndVisa;
using DataAccessLayer.Entites.TreatmentAndSurgery;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entites.PatientRelated
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string ContactInfo { get; set; }
        public int PassportId { get; set; }
        public virtual Passport Passport { get; set; }
        public string PhotoUrl { get; set; }



        // One Patient can have many MedicalReports, Appointments, and Costs
        public ICollection<MedicalReport> MedicalReports { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Cost> Costs { get; set; }
        public ICollection<TreatmentPlan> TreatmentPlans { get; set; }


        // One Patient can have one Visa
        public VisaProcessing Visa { get; set; }

       // public ICollection<PatientAttendent> PatientAttendents { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated



    }
}
