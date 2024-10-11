using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.InputModel
{
    public class CustomerCallRequestInputModel
    {
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string? Status { get; set; }
        public string? StatusMessage { get; set; }
    }

}
