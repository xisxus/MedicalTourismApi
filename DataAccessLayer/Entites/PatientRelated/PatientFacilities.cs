using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entites.PatientRelated
{
    public class PatientFacilities
    {
        public int PatientFacilitiesId { get; set; }
        public string PatientFacilitiesName { get; set; }
        public int PatientsTravelId { get; set; }
        public virtual PatientsTravel PatientsTravel { get; set; }


    }
}
