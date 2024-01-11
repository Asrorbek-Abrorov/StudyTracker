using Spectre.Console;
using StudyTracker.Entities;
using StudyTracker.Services;
using StudyTracker.Uis;

namespace StudyTracker;

public class Program
{
    static void Main()
    {
        var studentService = new StudentService();
        var courseService = new CourseService();
        var studyPlanService = new StudyPlanService();
        var progressRecordService = new ProgressRecordService();

        var studentUi = new StudentUi(studentService);
        var courseUi = new CourseUi(courseService);
        var studyPlanUi = new StudyPlanUi(studyPlanService);
        var progressRecordUi = new ProgressRecordUi(progressRecordService);

        studentUi.Register();

        // Add sample courses
        courseService.AddCourse(new Course { CourseName = "Mathematics", InstructorName = "John Doe", Schedule = "MWF 10:00 AM - 11:30 AM", Credits = 3 });
        courseService.AddCourse(new Course { CourseName = "Physics", InstructorName = "Jane Smith", Schedule = "TTh 1:00 PM - 2:30 PM", Credits = 4 });

        // Add sample study plans
        studyPlanService.AddStudyPlan(new StudyPlan { Course = courseService.GetCourses()[0], StudyMaterials = "Textbook, Lecture notes", Topics = "Algebra, Calculus", StudyHoursPerWeek = 10 });
        studyPlanService.AddStudyPlan(new StudyPlan { Course = courseService.GetCourses()[1], StudyMaterials = "Textbook, Lab manual", Topics = "Mechanics, Thermodynamics", StudyHoursPerWeek = 8 });

        // Add sample progress records
        progressRecordService.AddProgressRecord(new ProgressRecord { Course = courseService.GetCourses()[0], Date = DateTime.Now, DurationInMinutes = 90, StudyMaterialsCovered = "Chapter 1" });
        progressRecordService.AddProgressRecord(new ProgressRecord { Course = courseService.GetCourses()[1], Date = DateTime.Now, DurationInMinutes = 120, StudyMaterialsCovered = "Labs 1-3" });

        AnsiConsole.WriteLine();
        studentUi.Login();

        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("[bold]=== Course Details ===[/]");
        courseUi.DisplayCourseDetails();

        AnsiConsole.WriteLine("[bold]=== Study Plans ===[/]");
        studyPlanUi.DisplayStudyPlans();

        AnsiConsole.WriteLine("[bold]=== Progress Records ===[/]");
        progressRecordUi.DisplayProgressRecords();
    }
}
