using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.OutputModel
{
    public class FeedbackOutputModel
    {
        public int FeedbackID { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Patient Details
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientPhotoUrl { get; set; }

        // Hospital Details
        public int HospitalID { get; set; }
        public string HospitalName { get; set; }
        public string HospitalAddress { get; set; }
        public string HospitalPhotoUrl { get; set; }
        public string HospitalLogo { get; set; }
    }

}
