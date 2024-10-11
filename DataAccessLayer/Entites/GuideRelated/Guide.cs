using DataAccessLayer.Entites.PatientRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entites.GuideRelated
{
    public class Guide
    {
        public int GuideId { get; set; }
        public string GuidName { get; set; }
        public string PhoneNo { get; set; }
        public string GuidePhotoUrl { get; set; }

        // One Guid can be assigned to many Patients
        public ICollection<PatientsTravel> PatientsTravels { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated
    }
}
