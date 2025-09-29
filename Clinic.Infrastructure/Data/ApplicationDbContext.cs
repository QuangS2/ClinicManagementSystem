using Clinic.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,IdentityRole,String>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Patient> Patients { get; set; } = null!;
        //public DbSet<ApplicationUser> Users { get; set; } = null!;

        //appointments
        public DbSet<Appointment> Appointments { get; set; } = null!;
        //Medical Records
        public DbSet<MedicalRecord> MedicalRecords { get; set; } = null!;

        //Invoices
        public DbSet<Invoice> Invoices { get; set; } = null!;
        //Payments
        public DbSet<Payment> Payments { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // appointment has one patient with many appointments
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            // appointment has one doctor with many appointments
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);


            //Medical Record configuration
            //MedicalRecord has one patient with many medical records and delete patient will not delete medical records
            modelBuilder.Entity<MedicalRecord>()
                .HasOne(m => m.Patient)
                .WithMany(p => p.MedicalRecords)
                .HasForeignKey(m => m.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            //MedicalRecord has one doctor with many medical records and delele doctor will not delete medical records
            modelBuilder.Entity<MedicalRecord>()
                .HasOne(m => m.Doctor)
                .WithMany(d => d.MedicalRecords)
                .HasForeignKey(m => m.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
            //MedicalRecord has one appointment and delete medical record when appointment is deleted
            modelBuilder.Entity<MedicalRecord>()
                .HasOne(m => m.Appointment)
                .WithOne(a => a.MedicalRecord)
                .HasForeignKey<MedicalRecord>(m => m.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);
            //Invoice configuration
            //invoice has one patient with many invoices, delete patient will not delete invoices
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Patient)
                .WithMany(p => p.Invoices)
                .HasForeignKey(i => i.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
            //invoice has one appointment with one invoices, delete appointment will delete invoices
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Appointment)
                .WithOne(a => a.Invoice)
                .HasForeignKey<Invoice>(i => i.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            //Payment configuration
            //payment has one invoice with many payments, delete invoice will delete payments
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Invoice)
                .WithMany(i => i.Payments)
                .HasForeignKey(p => p.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
