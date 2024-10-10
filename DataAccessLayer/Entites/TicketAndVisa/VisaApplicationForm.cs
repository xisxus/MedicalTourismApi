using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entites.TicketAndVisa
{
    public class VisaApplicationForm
    {
        //public class PersonalParticulars
        public int VisaApplicationFormID { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string PreviousName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Religion { get; set; }
        public string PlaceOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public string CitizenshipId { get; set; }
        public string EducationalQualification { get; set; }
        public string IdentificationMarks { get; set; }
        public string CurrentNationality { get; set; }
        public string NationalityType { get; set; }
        public string PreviousNationality { get; set; }


        public int PassportId { get; set; }
        public virtual Passport Passport { get; set; }


        //public class PassportDetails

        //public string PassportNo { get; set; }
        //public DateTime DateOfIssue { get; set; }
        //public string PlaceOfIssue { get; set; }
        //public DateTime DateOfExpiry { get; set; }
        //public bool OtherPassportHeld { get; set; }

        //public class OtherPassportOrIdentityCertificate

        public bool HasOtherPassportOrIdentityCertificate { get; set; }
        public string CountryOfIssue { get; set; }
        public string PassportOrICNumber { get; set; }
        public string PassportPlaceOfIssue { get; set; }
        public DateTime? PassportDateOfIssue { get; set; }



    


        //public class ContactDetails

        public string PresentAddress { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string PermanentAddress { get; set; }


        //public class FamilyMember

        public string Relation { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string FDPreviousNationality { get; set; }
        public string FDPlaceOfBirth { get; set; }


        //public class VisaDetails

        public string VisaType { get; set; }
        public string Entries { get; set; }
        public int Period { get; set; }
        public DateTime ExpectedDateOfJourney { get; set; }
        public string PortOfArrival { get; set; }
        public string PortOfExit { get; set; }


        //public class MedicalVisaDetails

        //public string HospitalName { get; set; }
        //public string HospitalAddress { get; set; }
        //public string DoctorName { get; set; }
        //public string HospitalPhone { get; set; }
        //public string MedicalDetails { get; set; }
        //public string ResidenceHospitalName { get; set; }
        //public string ResidenceAddress { get; set; }
        //public string ResidenceDoctorName { get; set; }

        public string PurposeOfVisit { get; set; }

        //public class PreviousVisitDetails

        public bool HaveYouVisitedIndia { get; set; }
        public string AddressStayedInIndia { get; set; }
        public List<string> CitiesVisitedInIndia { get; set; }
        public string TypeOfVisa { get; set; }
        public string VisaNumber { get; set; }
        public string VisaIssuedPlace { get; set; }
        public DateTime? VisaIssueDate { get; set; }
        public List<string> CountriesVisitedLast10Years { get; set; }
        public bool BeenRefusedIndianVisaOrDeported { get; set; }



        //public class ProfessionDetails

        public string PresentOccupation { get; set; }
        public string DesignationOrRank { get; set; }
        public string EmployerNameOrBusiness { get; set; }
        public string EmployerAddress { get; set; }
        public string EmployerPhone { get; set; }
        public string PastOccupationIfAny { get; set; }
        public bool AreHaveYouWorkedWithArmedforcesPoliceParaMilitaryforces { get; set; }
        public string Organization { get; set; }
        public string Designation { get; set; }
        public string PlaceofPosting { get; set; }
        public string Rank { get; set; }


        //public class StayDetails

        public string IndianHotelPlaceName { get; set; }
        public string IndianHotelAddress { get; set; }
        public string IndianHotelState { get; set; }
        public string IndianHotelPhoneNo { get; set; }


        //public class Reference in india

        public string IndianRefName { get; set; }
        public string IndianRefAddress { get; set; }
        public string IndianRefPhoneNumber { get; set; }

        public string BanRefName { get; set; }
        public string BanRefAddress { get; set; }
        public string BanRefPhoneNumber { get; set; }





        public ICollection<VisaApply> VisaApplies { get; set; }

    }
}
