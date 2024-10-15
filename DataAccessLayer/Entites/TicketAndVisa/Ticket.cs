using DataAccessLayer.Entites.PatientRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entites.TicketAndVisa
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public decimal TicketPrice { get; set; }
        public string TransportationType { get; set; }  //bus , train , Air
        public string TransportationCompany { get; set; } // Hanif , BR, Indigo
        public string DestinationCity { get; set; } // Kolkata
        public DateTime ArrivelTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp when the entry was created
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  // Timestamp when the entry was last updated
        //TODO:PatientTravelId should be have 
       
        public int PatientsTravelId { get; set; }

        public virtual PatientsTravel PatientsTravel { get; set; }


    }
}
