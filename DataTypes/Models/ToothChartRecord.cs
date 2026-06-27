namespace DataTypes.Models;

public class ToothChartRecord
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public Patient Patient { get; set; } = null!;

    public string ToothNumber { get; set; } = string.Empty;

    public string Condition { get; set; } = string.Empty;

    public string? Surface { get; set; }

    public string? Notes { get; set; }

    public DateTime RecordedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}