using Spectre.Console;
using StudyTracker.Entities;

namespace StudyTracker.Services;

public class StudentService
{
    private const string StudentsFilePath = "../../../../StudyTracker/src/students.txt";

    public void RegisterStudent(Student student)
    {
        var students = GetStudents();
        students.Add(student);
        SaveStudents(students);

        AnsiConsole.MarkupLine("[bold green]Registration successful![/]");
    }

    public bool LoginStudent(string email, string password)
    {
        var students = GetStudents();
        return students.Exists(s => s.Email == email && s.Password == password);
    }

    private List<Student> GetStudents()
    {
        if (!File.Exists(StudentsFilePath))
        {
            return new List<Student>();
        }

        var lines = File.ReadAllLines(StudentsFilePath);
        var students = new List<Student>();

        foreach (var line in lines)
        {
            var parts = line.Split('|');
            if (parts.Length == 3)
            {
                var student = new Student
                {
                    Name = parts[0],
                    Email = parts[1],
                    Password = parts[2]
                };

                students.Add(student);
            }
        }

        return students;
    }

    private void SaveStudents(List<Student> students)
    {
        var lines = new List<string>();

        foreach (var student in students)
        {
            var line = $"{student.Name}|{student.Email}|{student.Password}";
            lines.Add(line);
        }

        File.WriteAllLines(StudentsFilePath, lines);
    }
}
