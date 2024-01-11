using System;
using Spectre.Console;
using StudyTracker.Entities;
using StudyTracker.Services;

namespace StudyTracker.Uis
{
    public class MainUi
    {
        private readonly CourseUi _courseUi;
        private readonly StudyPlanUi _studyPlanUi;
        private readonly ProgressRecordUi _progressRecordUi;
        private readonly StudentUi _studentUi;
        private readonly CourseService _courseService;

        public MainUi(CourseService courseService, StudyPlanService studyPlanService, ProgressRecordService progressRecordService, StudentService studentService)
        {
            _courseService = courseService;
            _courseUi = new CourseUi(courseService);
            _studyPlanUi = new StudyPlanUi(studyPlanService);
            _progressRecordUi = new ProgressRecordUi(progressRecordService);
            _studentUi = new StudentUi(studentService);
        }

        public void Run()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                AnsiConsole.Clear();
                AnsiConsole.Write(
                    new FigletText("* Main Menu *")
                        .LeftJustified()
                        .Color(Color.Red1));
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[green]*** Choose an option ***[/]?")
                        .PageSize(10)
                        .AddChoices(new[]
                        {
                            "Course Details", "Study Plans",
                            "Progress Records", "Register", "Login",
                            "Create Course", "Exit"
                        }));
                switch (choice)
                {
                    case "Course Details":
                        _courseUi.DisplayCourseDetails();
                        break;

                    case "Study Plans":
                        _studyPlanUi.DisplayStudyPlans();
                        break;

                    case "Progress Records":
                        _progressRecordUi.DisplayProgressRecords();
                        break;

                    case "Register":
                        _studentUi.Register();
                        break;

                    case "Login":
                        _studentUi.Login();
                        break;

                    case "Create Course":
                        CreateCourse();
                        break;

                    case "Exit":
                        keepRunning = false;
                        break;
                }
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("[yellow]Press Enter to continue...[/]");
                Console.ReadKey(true);
            }
        }

        private void CreateCourse()
        {
            var course = new Course();

            AnsiConsole.WriteLine("[bold green]Enter course details:[/]");
            course.CourseName = AnsiConsole.Ask<string>("Course Name:");
            course.InstructorName = AnsiConsole.Ask<string>("Instructor Name:");
            course.Schedule = AnsiConsole.Ask<string>("Schedule:");
            course.Credits = AnsiConsole.Ask<int>("Credits:");

            _courseService.SaveCourse(course);
            AnsiConsole.WriteLine("[bold green]Course saved successfully![/]");
        }
    }
}