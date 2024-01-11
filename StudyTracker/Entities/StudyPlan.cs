namespace StudyTracker.Entities;

public class StudyPlan
{
    public Course Course { get; set; }
    public string StudyMaterials { get; set; }
    public string Topics { get; set; }
    public int StudyHoursPerWeek { get; set; }
}