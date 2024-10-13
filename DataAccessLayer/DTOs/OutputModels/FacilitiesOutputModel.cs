using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.OutputModels
{
    public class FacilitiesOutputModel
    {
        public int FacilitiesId { get; set; }
        public string FacilitiesDescription { get; set; }

        // Include related hospital facilities data
        public List<HospitalFacilitiesOutputModel> HospitalFacilities { get; set; }
    }
    public class HospitalFacilitiesOutputModel
    {
        public int HospitalFacilitiesId { get; set; }
        public int HospitalID { get; set; }
        public string HospitalName { get; set; } // Include the hospital name for display purposes
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
