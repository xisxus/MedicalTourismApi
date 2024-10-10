using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entites.HospitalRelated
{
    public class Facilities
    {
        public int FacilitiesId { get; set; }
        public string FacilitiesDescription { get; set; }

        public ICollection<HospitalFacilities> HospitalFacilities { get; set; }
    }
}
