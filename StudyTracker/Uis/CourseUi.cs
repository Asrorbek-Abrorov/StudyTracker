using Spectre.Console;
using StudyTracker.Services;

namespace StudyTracker.Uis;

public class CourseUi
{
    private readonly CourseService courseService;

    public CourseUi(CourseService courseService)
    {
        this.courseService = courseService;
    }

    public void DisplayCourseDetails()
    {
        var course = courseService.GetCourse();

        if (course != null)
        {
            var table = new Table().Border(TableBorder.Rounded);
            table.AddColumn("Course Name");
            table.AddColumn("Instructor");
            table.AddColumn("Schedule");
            table.AddColumn("Credits");

            table.AddRow(course.CourseName, course.InstructorName, course.Schedule, course.Credits.ToString());

            AnsiConsole.Render(table);
        }
        else
        {
            AnsiConsole.MarkupLine("[bold red]No course found.[/]");
        }
    }
}