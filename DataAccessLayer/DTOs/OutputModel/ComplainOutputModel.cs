using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.OutputModel
{
    public class ComplainOutputModel
    {
        public int ComplainId { get; set; }
        public string ComplainType { get; set; }
        public string ComplainDescription { get; set; }
        public string ComplainStatus { get; set; }
        public DateTime ComplainDate { get; set; }
    }

}
