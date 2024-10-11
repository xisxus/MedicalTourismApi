using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.OutputModel
{
    public class CommissionOutputModel
    {
        public int CommissionID { get; set; }
        public int AgentID { get; set; }
        public string AgentFullName { get; set; } // Combined first and last name
        public int PatientID { get; set; }
        public decimal CommissionAmount { get; set; }
        public DateTime DateEarned { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
