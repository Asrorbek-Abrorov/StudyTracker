using Spectre.Console;
using StudyTracker.Services;

namespace StudyTracker.Uis
{
    public class MainUi
    {
        private readonly CourseUi _courseUi;
        private readonly StudyPlanUi _studyPlanUi;
        private readonly ProgressRecordUi _progressRecordUi;
        private readonly StudentUi _studentUi;

        public MainUi(CourseService courseService, StudyPlanService studyPlanService, ProgressRecordService progressRecordService, StudentService studentService)
        {
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
                    .LeftAligned()
                    .Color(Color.Red1));
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[green]*** Choose an option ***[/]?")
                        .PageSize(10)
                        .AddChoices(new[]
                        {
                            "Course Details", "Study Plans",
                            "Progress Records", "Register", "Login",
                            "Exit"
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

                    case "Exit":
                        keepRunning = false;
                        break;
                }
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("[yellow]Press Enter to continue...[/]");
                Console.ReadKey(true);
            }
        }
    }
}