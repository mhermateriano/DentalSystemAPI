namespace DataTypes.Models;

public class PaymentTransaction
{
    public int Id { get; set; }

    public string TransactionNumber { get; set; } = string.Empty;

    public int TreatmentRecordId { get; set; }

    public TreatmentRecord TreatmentRecord { get; set; } = null!;

    public int? ReceivedByUserId { get; set; }

    public User? ReceivedByUser { get; set; }

    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

    public decimal AmountPaid { get; set; }

    public string PaymentMethod { get; set; } = "Cash";

    public string PaymentType { get; set; } = "TreatmentPayment";

    public string? ReferenceNumber { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}