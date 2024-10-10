using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entites.TicketAndVisa
{
    public class VisaProcessing
    {
        public int VisaProcessingID { get; set; }
        public int VisaApplyID { get; set; }
        public string VisaStatus { get; set; }
        public decimal ProcessingFee { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime AppoinmentDate { get; set; }


        public string PassportStatus { get; set; }
        public string ApplicationForm { get; set; }
        public string PhotoStatus { get; set; }
        public string ProofOfResidenceStatus { get; set; }
        public string ProofOfFinancialSoundnessStatus { get; set; }
        public string ProofOfProfessionStatus { get; set; }
        public string HospitalAppointmentLetter { get; set; }
        public string NationalIDOrBirthCertificate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
