using Spectre.Console;
using StudyTracker.Entities;
using StudyTracker.Services;

namespace StudyTracker.Uis;

public class StudentUi
{
    private readonly StudentService studentService;

    public StudentUi(StudentService studentService)
    {
        this.studentService = studentService;
    }

    public void Register()
    {
        var student = new Student();

        student.Name = AnsiConsole.Ask<string>("Name:");
        student.Email = AnsiConsole.Ask<string>("Email:");
        student.Password = AnsiConsole.Ask<string>("Password:");

        studentService.RegisterStudent(student);

        AnsiConsole.MarkupLine("[bold green]Registration successful![/]");
    }

    public void Login()
    {
        string email = AnsiConsole.Ask<string>("Email:");
        string password = AnsiConsole.Ask<string>("Password:");

        bool loginSuccessful = studentService.LoginStudent(email, password);

        if (loginSuccessful)
        {
            AnsiConsole.MarkupLine("[bold green]Login successful![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[bold red]Login failed. Invalid email or password.[/]");
        }
    }
}