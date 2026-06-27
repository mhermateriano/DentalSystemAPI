namespace DataTypes.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string PatientNumber { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = string.Empty;

    public string? Suffix { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? Gender { get; set; }

    public string? CivilStatus { get; set; }

    public string? Occupation { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? EmergencyContactName { get; set; }

    public string? EmergencyContactNumber { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public MedicalHistory? MedicalHistory { get; set; }

    public ICollection<TreatmentRecord> TreatmentRecords { get; set; } = new List<TreatmentRecord>();

    public ICollection<ToothChartRecord> ToothChartRecords { get; set; } = new List<ToothChartRecord>();
}