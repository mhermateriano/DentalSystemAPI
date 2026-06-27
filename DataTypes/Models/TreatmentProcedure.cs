namespace DataTypes.Models;

public class TreatmentProcedure
{
    public int Id { get; set; }

    public int TreatmentRecordId { get; set; }

    public TreatmentRecord TreatmentRecord { get; set; } = null!;

    public int? DentalServiceId { get; set; }

    public DentalService? DentalService { get; set; }

    public string ProcedureName { get; set; } = string.Empty;

    public string? ToothNumber { get; set; }

    public string? Surface { get; set; }

    public string? Description { get; set; }

    public decimal Quantity { get; set; } = 1;

    public decimal UnitPrice { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = "Completed";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}