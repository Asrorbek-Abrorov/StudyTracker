using Spectre.Console;
using StudyTracker.Entities;

namespace StudyTracker.Services;

public class StudyPlanService
{
    private const string StudyPlanFilePath = "../../../../StudyTracker/src/studyplan.txt";

    public void SaveStudyPlan(StudyPlan studyPlan)
    {
        var lines = new List<string>
        {
            $"CourseName: {studyPlan.Course.CourseName}",
            $"InstructorName: {studyPlan.Course.InstructorName}",
            $"Schedule: {studyPlan.Course.Schedule}",
            $"Credits: {studyPlan.Course.Credits}",
            $"StudyMaterials: {studyPlan.StudyMaterials}",
            $"Topics: {studyPlan.Topics}",
            $"StudyHoursPerWeek: {studyPlan.StudyHoursPerWeek}"
        };

        File.WriteAllLines(StudyPlanFilePath, lines);
        AnsiConsole.MarkupLine("[bold green]Study plan saved successfully![/]");
    }

    public StudyPlan GetStudyPlan()
    {
        if (!File.Exists(StudyPlanFilePath))
        {
            return null;
        }

        var lines = File.ReadAllLines(StudyPlanFilePath);
        var studyPlan = new StudyPlan();
        studyPlan.Course = new Course();

        foreach (var line in lines)
        {
            var parts = line.Split(':');
            if (parts.Length == 2)
            {
                var key = parts[0].Trim();
                var value = parts[1].Trim();

                switch (key)
                {
                    case "CourseName":
                        studyPlan.Course.CourseName = value;
                        break;
                    case "InstructorName":
                        studyPlan.Course.InstructorName = value;
                        break;
                    case "Schedule":
                        studyPlan.Course.Schedule = value;
                        break;
                    case "Credits":
                        int credits;
                        if (int.TryParse(value, out credits))
                        {
                            studyPlan.Course.Credits = credits;
                        }
                        break;
                    case "StudyMaterials":
                        studyPlan.StudyMaterials = value;
                        break;
                    case "Topics":
                        studyPlan.Topics = value;
                        break;
                    case "StudyHoursPerWeek":
                        int studyHoursPerWeek;
                        if (int.TryParse(value, out studyHoursPerWeek))
                        {
                            studyPlan.StudyHoursPerWeek = studyHoursPerWeek;
                        }
                        break;
                }
            }
        }

        return studyPlan;
    }
    public List<StudyPlan> GetStudyPlans()
    {
        if (!File.Exists(StudyPlanFilePath))
        {
            return new List<StudyPlan>();
        }

        var lines = File.ReadAllLines(StudyPlanFilePath);
        var studyPlans = new List<StudyPlan>();

        StudyPlan studyPlan = null;

        foreach (var line in lines)
        {
            var parts = line.Split(':');
            if (parts.Length == 2)
            {
                var key = parts[0].Trim();
                var value = parts[1].Trim();

                switch (key)
                {
                    case "CourseName":
                        studyPlan = new StudyPlan
                        {
                            Course = new Course
                            {
                                CourseName = value
                            }
                        };
                        break;
                    case "InstructorName":
                        studyPlan.Course.InstructorName = value;
                        break;
                    case "Schedule":
                        studyPlan.Course.Schedule = value;
                        break;
                    case "Credits":
                        int credits;
                        if (int.TryParse(value, out credits))
                        {
                            studyPlan.Course.Credits = credits;
                        }
                        break;
                    case "StudyMaterials":
                        studyPlan.StudyMaterials = value;
                        break;
                    case "Topics":
                        studyPlan.Topics = value;
                        break;
                    case "StudyHoursPerWeek":
                        int studyHoursPerWeek;
                        if (int.TryParse(value, out studyHoursPerWeek))
                        {
                            studyPlan.StudyHoursPerWeek = studyHoursPerWeek;
                        }
                        break;
                    case "":
                        studyPlans.Add(studyPlan);
                        break;
                }
            }
        }

        return studyPlans;
    }
}
