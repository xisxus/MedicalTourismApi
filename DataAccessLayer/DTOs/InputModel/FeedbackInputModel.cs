using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.InputModel
{
    public class FeedbackInputModel
    {
        public int PatientID { get; set; }
        public int HospitalID { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; } // e.g., from 1 to 5 stars
    }

}
