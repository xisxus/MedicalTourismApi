using DataAccessLayer.Entites.PatientRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entites.TreatmentAndSurgery
{
    public class Medicine
    {
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDateStates { get; set; }
        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated
    }
}
