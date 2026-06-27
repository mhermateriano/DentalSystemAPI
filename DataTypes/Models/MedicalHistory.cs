namespace DataTypes.Models;

public class MedicalHistory
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public Patient Patient { get; set; } = null!;

    public bool HasHeartDisease { get; set; }

    public bool HasDiabetes { get; set; }

    public bool HasHighBloodPressure { get; set; }

    public bool HasAsthma { get; set; }

    public bool HasBleedingDisorder { get; set; }

    public bool IsPregnant { get; set; }

    public bool HasAllergies { get; set; }

    public string? AllergyDetails { get; set; }

    public string? CurrentMedications { get; set; }

    public string? PreviousSurgeries { get; set; }

    public string? OtherMedicalConditions { get; set; }

    public string? PhysicianName { get; set; }

    public string? PhysicianContactNumber { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}