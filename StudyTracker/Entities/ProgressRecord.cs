namespace StudyTracker.Entities;

public class ProgressRecord
{
    public Course Course { get; set; }
    public DateTime Date { get; set; }
    public int DurationInMinutes { get; set; }
    public string StudyMaterialsCovered { get; set; }
}