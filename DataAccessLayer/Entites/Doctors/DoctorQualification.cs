using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entites.Doctors
{
    public class DoctorQualification
    {
        public int DoctorQualificationId { get; set; }
        public string QualificationName { get; set; }
        public string QualificationDescription { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
