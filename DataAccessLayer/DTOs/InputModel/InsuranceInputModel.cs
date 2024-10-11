using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.InputModel
{
    public class InsuranceInputModel
    {
        public string InsuranceProvider { get; set; }
        public string PolicyNumber { get; set; }
        public int PatientID { get; set; }
    }

}
