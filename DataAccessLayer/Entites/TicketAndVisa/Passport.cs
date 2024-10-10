using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entites.TicketAndVisa
{
    public class Passport
    {
        public int PassportId { get; set; }
        public string PassportNo { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public bool OtherPassportHeld { get; set; }
    }
}
