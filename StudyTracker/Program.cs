using Spectre.Console;
using StudyTracker.Entities;
using StudyTracker.Services;
using StudyTracker.Uis;

namespace StudyTracker
{
    public class Program
    {
        static void Main()
        {
            var courseService = new CourseService();
            var studyPlanService = new StudyPlanService();
            var progressRecordService = new ProgressRecordService();
            var studentService = new StudentService();

            var mainUi = new MainUi(courseService, studyPlanService, progressRecordService, studentService);
            mainUi.Run();
        }
    }
}