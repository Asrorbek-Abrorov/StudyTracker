using Spectre.Console;
using StudyTracker.Entities;

namespace StudyTracker.Services;

public class ProgressRecordService
{
    private const string ProgressRecordFilePath = "../../../../StudyTracker/src/progressrecord.txt";

    public void SaveProgressRecord(ProgressRecord progressRecord)
    {
        var lines = new List<string>
        {
            $"CourseName: {progressRecord.Course.CourseName}",
            $"InstructorName: {progressRecord.Course.InstructorName}",
            $"Schedule: {progressRecord.Course.Schedule}",
            $"Credits: {progressRecord.Course.Credits}",
            $"Date: {progressRecord.Date}",
            $"DurationInMinutes: {progressRecord.DurationInMinutes}",
            $"StudyMaterialsCovered: {progressRecord.StudyMaterialsCovered}"
        };

        File.WriteAllLines(ProgressRecordFilePath, lines);
        AnsiConsole.MarkupLine("[bold green]Progress record saved successfully![/]");
    }

    public ProgressRecord GetProgressRecord()
    {
        if (!File.Exists(ProgressRecordFilePath))
        {
            return null;
        }

        var lines = File.ReadAllLines(ProgressRecordFilePath);
        var progressRecord = new ProgressRecord();
        progressRecord.Course = new Course();

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
                        progressRecord.Course.CourseName = value;
                        break;
                    case "InstructorName":
                        progressRecord.Course.InstructorName = value;
                        break;
                    case "Schedule":
                        progressRecord.Course.Schedule = value;
                        break;
                    case "Credits":
                        int credits;
                        if (int.TryParse(value, out credits))
                        {
                            progressRecord.Course.Credits = credits;
                        }
                        break;
                    case "Date":
                        DateTime date;
                        if (DateTime.TryParse(value, out date))
                        {
                            progressRecord.Date = date;
                        }
                        break;
                    case "DurationInMinutes":
                        int durationInMinutes;
                        if (int.TryParse(value, out durationInMinutes))
                        {
                            progressRecord.DurationInMinutes = durationInMinutes;
                        }
                        break;
                    case "StudyMaterialsCovered":
                        progressRecord.StudyMaterialsCovered = value;
                        break;
                }
            }
        }

        return progressRecord;
    }
    
    public List<ProgressRecord> GetProgressRecords()
{
    if (!File.Exists(ProgressRecordFilePath))
    {
        return new List<ProgressRecord>();
    }

    var lines = File.ReadAllLines(ProgressRecordFilePath);
    var progressRecords = new List<ProgressRecord>();

    ProgressRecord progressRecord = null;

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
                    progressRecord = new ProgressRecord
                    {
                        Course = new Course
                        {
                            CourseName = value
                        }
                    };
                    break;
                case "InstructorName":
                    progressRecord.Course.InstructorName = value;
                    break;
                case "Schedule":
                    progressRecord.Course.Schedule = value;
                    break;
                case "Credits":
                    int credits;
                    if (int.TryParse(value, out credits))
                    {
                        progressRecord.Course.Credits = credits;
                    }
                    break;
                case "Date":
                    DateTime date;
                    if (DateTime.TryParse(value, out date))
                    {
                        progressRecord.Date = date;
                    }
                    break;
                case "DurationInMinutes":
                    int durationInMinutes;
                    if (int.TryParse(value, out durationInMinutes))
                    {
                        progressRecord.DurationInMinutes = durationInMinutes;
                    }
                    break;
                case "StudyMaterialsCovered":
                    progressRecord.StudyMaterialsCovered = value;
                    progressRecords.Add(progressRecord);
                    break;
            }
        }
    }

    return progressRecords;
}
}
