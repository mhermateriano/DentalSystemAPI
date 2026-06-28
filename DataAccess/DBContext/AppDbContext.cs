using DataTypes.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<MedicalHistory> MedicalHistories => Set<MedicalHistory>();

    public DbSet<DentalService> DentalServices => Set<DentalService>();

    public DbSet<TreatmentRecord> TreatmentRecords => Set<TreatmentRecord>();

    public DbSet<TreatmentProcedure> TreatmentProcedures => Set<TreatmentProcedure>();

    public DbSet<PaymentTransaction> PaymentTransactions => Set<PaymentTransaction>();

    public DbSet<ToothChartRecord> ToothChartRecords => Set<ToothChartRecord>();

    public DbSet<Prescription> Prescriptions => Set<Prescription>();

    public DbSet<User> Users => Set<User>();

    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigurePatient(modelBuilder);
        ConfigureMedicalHistory(modelBuilder);
        ConfigureDentalService(modelBuilder);
        ConfigureTreatmentRecord(modelBuilder);
        ConfigureTreatmentProcedure(modelBuilder);
        ConfigurePaymentTransaction(modelBuilder);
        ConfigureToothChartRecord(modelBuilder);
        ConfigurePrescription(modelBuilder);
        ConfigureUser(modelBuilder);
        ConfigureAuditLog(modelBuilder);
    }

    private static void ConfigurePatient(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.PatientNumber)
                .IsUnique();

            entity.Property(e => e.PatientNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.MiddleName)
                .HasMaxLength(100);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Suffix)
                .HasMaxLength(30);

            entity.Property(e => e.Gender)
                .HasMaxLength(30);

            entity.Property(e => e.CivilStatus)
                .HasMaxLength(50);

            entity.Property(e => e.Occupation)
                .HasMaxLength(150);

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(30);

            entity.Property(e => e.Email)
                .HasMaxLength(150);

            entity.Property(e => e.Address)
                .HasMaxLength(500);

            entity.Property(e => e.EmergencyContactName)
                .HasMaxLength(150);

            entity.Property(e => e.EmergencyContactNumber)
                .HasMaxLength(30);
        });
    }

    private static void ConfigureMedicalHistory(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicalHistory>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.AllergyDetails)
                .HasMaxLength(500);

            entity.Property(e => e.CurrentMedications)
                .HasMaxLength(1000);

            entity.Property(e => e.PreviousSurgeries)
                .HasMaxLength(1000);

            entity.Property(e => e.OtherMedicalConditions)
                .HasMaxLength(1000);

            entity.Property(e => e.PhysicianName)
                .HasMaxLength(150);

            entity.Property(e => e.PhysicianContactNumber)
                .HasMaxLength(30);

            entity.Property(e => e.Notes)
                .HasMaxLength(1000);

            entity.HasOne(e => e.Patient)
                .WithOne(e => e.MedicalHistory)
                .HasForeignKey<MedicalHistory>(e => e.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private static void ConfigureDentalService(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DentalService>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.ServiceCode)
                .IsUnique();

            entity.Property(e => e.ServiceCode)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.Description)
                .HasMaxLength(500);

            entity.Property(e => e.DefaultPrice)
                .HasPrecision(18, 2);
        });
    }

    private static void ConfigureTreatmentRecord(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TreatmentRecord>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.TreatmentNumber)
                .IsUnique();

            entity.Property(e => e.TreatmentNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.ChiefComplaint)
                .HasMaxLength(1000);

            entity.Property(e => e.Diagnosis)
                .HasMaxLength(1000);

            entity.Property(e => e.TreatmentNotes)
                .HasMaxLength(2000);

            entity.Property(e => e.PrescriptionNotes)
                .HasMaxLength(2000);

            entity.Property(e => e.PaymentStatus)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(e => e.TreatmentStatus)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(e => e.SubtotalAmount)
                .HasPrecision(18, 2);

            entity.Property(e => e.DiscountAmount)
                .HasPrecision(18, 2);

            entity.Property(e => e.TotalAmount)
                .HasPrecision(18, 2);

            entity.Property(e => e.PaidAmount)
                .HasPrecision(18, 2);

            entity.Property(e => e.BalanceAmount)
                .HasPrecision(18, 2);

            entity.HasOne(e => e.Patient)
                .WithMany(e => e.TreatmentRecords)
                .HasForeignKey(e => e.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.DentistUser)
                .WithMany(e => e.TreatmentRecords)
                .HasForeignKey(e => e.DentistUserId)
                .OnDelete(DeleteBehavior.SetNull);
        });
    }

    private static void ConfigureTreatmentProcedure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TreatmentProcedure>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.ProcedureName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.ToothNumber)
                .HasMaxLength(20);

            entity.Property(e => e.Surface)
                .HasMaxLength(100);

            entity.Property(e => e.Description)
                .HasMaxLength(1000);

            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(e => e.Quantity)
                .HasPrecision(18, 2);

            entity.Property(e => e.UnitPrice)
                .HasPrecision(18, 2);

            entity.Property(e => e.DiscountAmount)
                .HasPrecision(18, 2);

            entity.Property(e => e.TotalAmount)
                .HasPrecision(18, 2);

            entity.HasOne(e => e.TreatmentRecord)
                .WithMany(e => e.Procedures)
                .HasForeignKey(e => e.TreatmentRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.DentalService)
                .WithMany(e => e.TreatmentProcedures)
                .HasForeignKey(e => e.DentalServiceId)
                .OnDelete(DeleteBehavior.SetNull);
        });
    }

    private static void ConfigurePaymentTransaction(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PaymentTransaction>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.TransactionNumber)
                .IsUnique();

            entity.Property(e => e.TransactionNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.PaymentMethod)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.PaymentType)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(100);

            entity.Property(e => e.Notes)
                .HasMaxLength(1000);

            entity.Property(e => e.AmountPaid)
                .HasPrecision(18, 2);

            entity.HasOne(e => e.TreatmentRecord)
                .WithMany(e => e.PaymentTransactions)
                .HasForeignKey(e => e.TreatmentRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.ReceivedByUser)
                .WithMany(e => e.PaymentTransactions)
                .HasForeignKey(e => e.ReceivedByUserId)
                .OnDelete(DeleteBehavior.SetNull);
        });
    }

    private static void ConfigureToothChartRecord(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToothChartRecord>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.ToothNumber)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(e => e.Condition)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Surface)
                .HasMaxLength(100);

            entity.Property(e => e.Notes)
                .HasMaxLength(1000);

            entity.HasOne(e => e.Patient)
                .WithMany(e => e.ToothChartRecords)
                .HasForeignKey(e => e.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private static void ConfigurePrescription(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.MedicineName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.Dosage)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Frequency)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Duration)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Instructions)
                .HasMaxLength(1000);

            entity.HasOne(e => e.TreatmentRecord)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.TreatmentRecordId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private static void ConfigureUser(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.Username)
                .IsUnique();

            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.PasswordHash)
                .IsRequired();

            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(30);
        });
    }

    private static void ConfigureAuditLog(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Action)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.EntityName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Description)
                .HasMaxLength(1000);

            entity.HasOne(e => e.User)
                .WithMany(e => e.AuditLogs)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        });
    }
}