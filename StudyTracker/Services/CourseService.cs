using Spectre.Console;
using StudyTracker.Entities;

namespace StudyTracker.Services;

public class CourseService
{
    private const string CoursesFilePath = "/home/as_abrorov/RiderProjects/StudyTracker/StudyTracker/src/courses.txt";

    public void SaveCourse(Course course)
    {
        var lines = new List<string>
        {
            $"CourseName: {course.CourseName}",
            $"InstructorName: {course.InstructorName}",
            $"Schedule: {course.Schedule}",
            $"Credits: {course.Credits}"
        };

        File.WriteAllLines(CoursesFilePath, lines);
        AnsiConsole.WriteLine("[bold green]Course saved successfully![/]");
    }

    public Course GetCourse()
    {
        if (!File.Exists(CoursesFilePath))
        {
            return null;
        }

        var lines = File.ReadAllLines(CoursesFilePath);
        var course = new Course();

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
                        course.CourseName = value;
                        break;
                    case "InstructorName":
                        course.InstructorName = value;
                        break;
                    case "Schedule":
                        course.Schedule = value;
                        break;
                    case "Credits":
                        int credits;
                        if (int.TryParse(value, out credits))
                        {
                            course.Credits = credits;
                        }
                        break;
                }
            }
        }

        return course;
    }
}
