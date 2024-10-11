using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.OutputModel
{
    public class ActivityLogOutputModel
    {
        public int ActivityLogID { get; set; }
        public int PatientID { get; set; }
        public string ActivityType { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Patient details
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
    }

}
