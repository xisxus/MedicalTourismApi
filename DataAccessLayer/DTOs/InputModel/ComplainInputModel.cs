using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.InputModel
{
    public class ComplainInputModel
    {
        public string ComplainType { get; set; }
        public string ComplainDescription { get; set; }
        public string ComplainStatus { get; set; }
    }

}
