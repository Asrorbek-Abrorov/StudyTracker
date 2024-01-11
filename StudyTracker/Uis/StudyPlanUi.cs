using Spectre.Console;
using StudyTracker.Services;

namespace StudyTracker.Uis;

public class StudyPlanUi
{
    private readonly StudyPlanService studyPlanService;

    public StudyPlanUi(StudyPlanService studyPlanService)
    {
        this.studyPlanService = studyPlanService;
    }

    public void DisplayStudyPlans()
    {
        var studyPlans = studyPlanService.GetStudyPlans();

        var table = new Table().Border(TableBorder.Rounded);
        table.AddColumn("Course");
        table.AddColumn("Study Materials");
        table.AddColumn("Topics");
        table.AddColumn("Study Hours per Week");

        foreach (var studyPlan in studyPlans)
        {
            table.AddRow(studyPlan.Course.CourseName, studyPlan.StudyMaterials, studyPlan.Topics, studyPlan.StudyHoursPerWeek.ToString());
        }

        AnsiConsole.Render(table);
    }
}