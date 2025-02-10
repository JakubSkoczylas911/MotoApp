using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

namespace MotoApp;
public class App : IApp
{
    private readonly IRepository<Employee> _employeeRepository;
    public App(IRepository<Employee> employeeRepository)
    {
        _employeeRepository = employeeRepository;

    }
    public void Run()
    {
        Console.WriteLine("I'm here in Run() method");
        var employees = new[]
        {
            new Employee { FirstName = "Zuzanna" },
            new Employee { FirstName = "Adam" },
            new Employee { FirstName = "Piotr" }
        };
        foreach (var emplyee in employees)
        {
            _employeeRepository.Add(emplyee);
        }
        _employeeRepository.Save();
        var items = _employeeRepository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}


