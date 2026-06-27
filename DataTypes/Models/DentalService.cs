namespace DataTypes.Models;

public class DentalService
{
    public int Id { get; set; }

    public string ServiceCode { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal DefaultPrice { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public ICollection<TreatmentProcedure> TreatmentProcedures { get; set; } = new List<TreatmentProcedure>();
}