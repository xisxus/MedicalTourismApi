using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.OutputModel
{
    public class GuideOutputModel
    {
        public int GuideId { get; set; }
        public string GuidName { get; set; }
        public string PhoneNo { get; set; }
        public string GuidePhotoUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
