using Spectre.Console;
using StudyTracker.Services;

namespace StudyTracker.Uis;

public class ProgressRecordUi
{
    private readonly ProgressRecordService progressRecordService;

    public ProgressRecordUi(ProgressRecordService progressRecordService)
    {
        this.progressRecordService = progressRecordService;
    }

    public void DisplayProgressRecords()
    {
        var progressRecords = progressRecordService.GetProgressRecords();

        var table = new Table().Border(TableBorder.Rounded);
        table.AddColumn("Course");
        table.AddColumn("Date");
        table.AddColumn("Duration");
        table.AddColumn("Study Materials Covered");

        foreach (var progressRecord in progressRecords)
        {
            table.AddRow(progressRecord.Course.CourseName, progressRecord.Date.ToShortDateString(), progressRecord.DurationInMinutes.ToString(), progressRecord.StudyMaterialsCovered);
        }

        AnsiConsole.Render(table);
    }
}