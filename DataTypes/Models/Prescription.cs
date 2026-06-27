namespace DataTypes.Models;

public class Prescription
{
    public int Id { get; set; }

    public int TreatmentRecordId { get; set; }

    public TreatmentRecord TreatmentRecord { get; set; } = null!;

    public string MedicineName { get; set; } = string.Empty;

    public string Dosage { get; set; } = string.Empty;

    public string Frequency { get; set; } = string.Empty;

    public string Duration { get; set; } = string.Empty;

    public string? Instructions { get; set; }

    public DateTime PrescribedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}