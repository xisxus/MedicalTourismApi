using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.InputModel
{
    public class FollowUpInputModel
    {
        public int PatientID { get; set; }
        public DateTime FollowUpDate { get; set; }
        public string Notes { get; set; }
    }

}
