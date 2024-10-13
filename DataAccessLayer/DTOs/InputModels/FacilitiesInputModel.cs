using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.InputModels
{
    public class FacilitiesInputModel
    {
        public string FacilitiesDescription { get; set; }

        // Optionally include related hospital facilities during creation
        public List<HospitalFacilitiesInputModel> HospitalFacilities { get; set; }
    }
    public class HospitalFacilitiesInputModel
    {
        public int HospitalID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}
