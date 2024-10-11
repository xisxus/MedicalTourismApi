using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.OutputModel
{
    public class FollowUpOutputModel
    {
        public int FollowUpID { get; set; }
        public DateTime FollowUpDate { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Patient Details
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientPhotoUrl { get; set; }
    }

}
