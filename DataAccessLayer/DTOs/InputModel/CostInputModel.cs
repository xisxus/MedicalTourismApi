using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.InputModel
{
    public class CostInputModel
    {
        public int PatientID { get; set; }
        public string ServiceType { get; set; }
        public decimal Amount { get; set; }
    }

}
