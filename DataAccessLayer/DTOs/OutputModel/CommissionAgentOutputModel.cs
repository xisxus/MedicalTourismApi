using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.OutputModel
{
    public class CommissionAgentOutputModel
    {
        public int AgentID { get; set; }
        public string FullName { get; set; } // FirstName + LastName
        public string UserID { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal TotalCommissionEarned { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
