using DataAccessLayer.Entites;
using DataAccessLayer.Entites.CommisionAgent;
using DataAccessLayer.Entites.CustomerSupport;
using DataAccessLayer.Entites.Doctors;
using DataAccessLayer.Entites.Employees;
using DataAccessLayer.Entites.GuideRelated;
using DataAccessLayer.Entites.HospitalRelated;
using DataAccessLayer.Entites.LogAndComplain;
using DataAccessLayer.Entites.PatientRelated;
using DataAccessLayer.Entites.TicketAndVisa;
using DataAccessLayer.Entites.TreatmentAndSurgery;
using DataAccessLayer.Entites.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class AppDbContext (DbContextOptions options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmpDept> EmpDepts { get; set; }

        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public DbSet<EmployeeDocument> EmployeeDocuments { get; set; }



        public DbSet<ActivityLog> ActivityLogs { get; set; }
       
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<CustomerCallRequest> CustomerCallRequests { get; set; }
        public DbSet<CommissionAgent> CommissionAgents { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
       
        public DbSet<DoctorExperience> DoctorExperiences { get; set; }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FollowUp> FollowUps { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<HospitalFacilities> HospitalFacilities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Insurance> Insurances { get; set; }

        public DbSet<MedicalReport> MedicalReports { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
     //   public DbSet<PatientAttendent> patientAttendents { get; set; }
        public DbSet<PatientsTravel> PatientsTravels { get; set; }
        public DbSet<PatientFacilities> PatientFacilities { get; set; }
        public DbSet<DoctorQualification> DoctorQualifications { get; set; }
        public DbSet<Surgery> Surgeries { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        public DbSet<TreatmentPlan> TreatmentPlans { get; set; }

        public DbSet<VisaProcessing> Visas { get; set; }
        public DbSet<TeleMedichineRequest> TeleMedichineRequests { get; set; }
        public DbSet<Complain> Complains { get; set; }
        public DbSet<VisaApply> VisaApplies { get; set; }
        public DbSet<VisaApplicationForm> VisaApplicationForms { get; set; }
        public DbSet<ResidenceHospital> ResidenceHospitals { get; set; }
        public DbSet<ResidenceDoctor> ResidenceDoctors { get; set; }
        public DbSet<Passport> Passports { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);




            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
            });

            builder.Entity<EmpDept>()
               .HasOne(ed => ed.Employee)
               .WithMany(e => e.EmpDepts)
               .HasForeignKey(ed => ed.EmployeeId)
               .OnDelete(DeleteBehavior.Restrict); // This prevents cascading deletes for Employee

            builder.Entity<EmpDept>()
                .HasOne(ed => ed.Department)
                .WithMany(d => d.EmpDepts)
                .HasForeignKey(ed => ed.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);




            // Example: Configuring one-to-many relationship between CommissionAgent and Commission
            builder.Entity<Commission>()
                .HasOne(c => c.CommissionAgent)
                .WithMany(a => a.Commissions)
                .HasForeignKey(c => c.AgentID);



            // Example: Configuring one-to-many relationship between Patient and MedicalReport
            builder.Entity<MedicalReport>()
                .HasOne(mr => mr.Patient)
                .WithMany(p => p.MedicalReports)
                .HasForeignKey(mr => mr.PatientID);

            // Add any further custom configurations here

            builder.Entity<CommissionAgent>()
        .HasKey(ca => ca.AgentID);

            // Define relationships if necessary
            builder.Entity<CommissionAgent>()
                .HasOne(ca => ca.ApplicationUser)
                .WithMany()  // Assuming one user can be associated with multiple agents
                .HasForeignKey(ca => ca.UserID);

            builder.Entity<Commission>()
                .HasOne(c => c.CommissionAgent)
                .WithMany(ca => ca.Commissions)
                .HasForeignKey(c => c.AgentID);



            builder.Entity<CommissionAgent>()
                 .HasOne(ca => ca.ApplicationUser)
                 .WithMany()  // Assuming each ApplicationUser can have multiple CommissionAgents
                 .HasForeignKey(ca => ca.UserID);



            // Define relationships for Hospital and Appointment
            builder.Entity<Hospital>()
                .HasMany(h => h.Appointments)
                .WithOne(a => a.Hospital)
                .HasForeignKey(a => a.HospitalID);

            builder.Entity<Guide>()
        .HasKey(g => g.GuidID);





            builder.Entity<TreatmentPlan>(entity =>
            {
                entity.HasKey(e => e.TreatmentPlanID);

                entity.Property(e => e.RefNo).IsRequired();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.StayingHospitalDuration).IsRequired();
                entity.Property(e => e.StayingOutsideDuration).IsRequired();
                entity.Property(e => e.CostCurrency).IsRequired();
                entity.Property(e => e.EstimatedCost).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.UpdatedAt).IsRequired();

                entity.HasOne(e => e.Patient)
                      .WithMany(p => p.TreatmentPlans)
                      .HasForeignKey(e => e.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Doctor)
                      .WithMany(d => d.TreatmentPlans)
                      .HasForeignKey(e => e.DoctorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Hospital)
                      .WithMany(h => h.TreatmentsPlans)
                      .HasForeignKey(e => e.HospitalId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.ResidenceDoctor)
                      .WithMany()
                      .HasForeignKey(e => e.ResidenceDoctorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.ResidenceHospital)
                      .WithMany()
                      .HasForeignKey(e => e.ResidenceHospitalId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }


    }

}

