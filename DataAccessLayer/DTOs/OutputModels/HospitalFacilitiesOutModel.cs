using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.OutputModels
{
    public class HospitalFacilitiesOutModel
    {
        public int HospitalFacilitiesId { get; set; }  // Unique identifier for HospitalFacilities
        public int FacilitiesId { get; set; }          // To display linked Facilities ID
        public string FacilitiesDescription { get; set; } // To display Facilities description
        public int HospitalID { get; set; }            // To display linked Hospital ID
        public string HospitalName { get; set; }       // To display Hospital name
        public DateTime CreatedAt { get; set; }        // When the record was created
        public DateTime UpdatedAt { get; set; }
    }
}
