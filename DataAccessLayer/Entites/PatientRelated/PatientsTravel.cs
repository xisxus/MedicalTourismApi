using DataAccessLayer.Entites.GuideRelated;
using DataAccessLayer.Entites.TicketAndVisa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entites.PatientRelated
{
    public class PatientsTravel
    {
        public int PatientsTravelId { get; set; }
        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }

        public int GuidID { get; set; }
        public virtual Guide Guide { get; set; }
        public string PickupLandMark { get; set; }
        public int TicketID { get; set; }
        public virtual Ticket Ticket { get; set; }


        public ICollection<PatientFacilities> PatientFacilities { get; set; }
    }
}
