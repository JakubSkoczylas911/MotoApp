using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Repositories;
var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
AddEmployees(employeeRepository);
WriteAllToConsole(employeeRepository);
static void AddEmployees(IRepository<Employee> employeeRepository)
{
    var employees = new[]
    {
        new Employee { FirstName = "Adam" },
        new Employee { FirstName = "Piotr" },
        new Employee { FirstName = "Zuzia" }
    };
    AddBatch(employeeRepository, employees);
}
static void AddBatch<T>(IRepository<T> repository, T[] items)
    where T : class, IEntity
{
    foreach (var employee in items)
    {
        repository.Add(employee);
    }
    repository.Save();
}
static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}