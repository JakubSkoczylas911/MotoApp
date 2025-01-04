using Microsoft.Extensions.DependencyInjection;
using MotoApp;
var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();
////using MotoApp.Data;
////using MotoApp.Entities;
////using MotoApp.Repositories;
////using MotoApp.Repositories.Extensions;

////var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), EmployeeAdded);
////employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
////static void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
////{
////    Console.WriteLine($"Employee added=>{e.FirstName} from{sender?.GetType().Name}");
////}
////AddEmployees(employeeRepository);
////WriteAllToConsole(employeeRepository);
////static void EmployeeAdded(object item)
////{
////    var employee = (Employee)item;
////    Console.WriteLine($"{employee.FirstName}added");
////}
////static void AddEmployees(IRepository<Employee> repository)
////{
////    var employees = new[]
////    {
////        new Employee {FirstName="Adam"},
////        new Employee {FirstName="Piotr" },
////        new Employee {FirstName="Zuzanna" },
////    };
////    repository.AddBatch(employees);
////    //    AddBatch(employeeRepository, employees);
////    //}
////    //static void AddBatch<T>(IRepository<T> repository, T[] items)
////    //    where T : class, IEntity
////    //{
//    //    foreach (var item in items)
//    //    {
//    //        repository.Add(item);
//    //    }
//    //    repository.Save();
//    //}

//}
//static void WriteAllToConsole(IReadRepository<IEntity> repository)
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(item);
//    }
//}