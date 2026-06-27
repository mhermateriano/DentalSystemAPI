namespace DataTypes.Models;

public class TreatmentRecord
{
    public int Id { get; set; }

    public string TreatmentNumber { get; set; } = string.Empty;

    public int PatientId { get; set; }

    public Patient Patient { get; set; } = null!;

    public int? DentistUserId { get; set; }

    public User? DentistUser { get; set; }

    public DateTime TreatmentDate { get; set; } = DateTime.UtcNow;

    public string? ChiefComplaint { get; set; }

    public string? Diagnosis { get; set; }

    public string? TreatmentNotes { get; set; }

    public string? PrescriptionNotes { get; set; }

    public decimal SubtotalAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal PaidAmount { get; set; }

    public decimal BalanceAmount { get; set; }

    public string PaymentStatus { get; set; } = "Unpaid";

    public string TreatmentStatus { get; set; } = "Completed";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public ICollection<TreatmentProcedure> Procedures { get; set; } = new List<TreatmentProcedure>();

    public ICollection<PaymentTransaction> PaymentTransactions { get; set; } = new List<PaymentTransaction>();

    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}