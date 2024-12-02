using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Repositories;
var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
AddEmployees(employeeRepository);
AddManagers(employeeRepository);
WriteAllToConsole(employeeRepository);
static void AddEmployees(IRepository<Employee> employeeReository)
{
    employeeReository.Add(new Employee { FirstName = "Adam" });
    employeeReository.Add(new Employee { FirstName = "Piotr" });
    employeeReository.Add(new Employee { FirstName = "Zuzia" });
    employeeReository.Save();
}
static void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Przemek" });
    managerRepository.Add(new Manager { FirstName = "Tomek" });
    managerRepository.Save();
}
static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
