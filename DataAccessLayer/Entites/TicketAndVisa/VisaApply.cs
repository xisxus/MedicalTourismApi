using DataAccessLayer.Entites.TreatmentAndSurgery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entites.TicketAndVisa
{
    public class VisaApply
    {
        public int VisaApplyID { get; set; }
        public int VisaApplicationFormID { get; set; }
        public VisaApplicationForm VisaApplicationForm { get; set; }
        public int TreatmentPlanID { get; set; }
        public TreatmentPlan TreatmentPlan { get; set; }
        public string VisaApplyFor { get; set; }//patient or attendant


    }
}
