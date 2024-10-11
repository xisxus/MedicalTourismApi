using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.InputModel
{
    public class CommissionInputModel
    {
        public int AgentID { get; set; }
        public int PatientID { get; set; }
        public decimal CommissionAmount { get; set; }
        public DateTime DateEarned { get; set; }
    }

}
