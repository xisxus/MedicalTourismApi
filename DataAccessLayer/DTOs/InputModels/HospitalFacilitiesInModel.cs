using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.InputModels
{
    public class HospitalFacilitiesInModel
    {
        public int FacilitiesId { get; set; }  // To link to the Facilities entity
        public int HospitalID { get; set; }    // To link to the Hospital entity
    }
}
