﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MotoApp;
using MotoApp.Components.CsvReader;
using MotoApp.Data;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();

services.AddSingleton<ICsvReader, CsvReader>();
services.AddDbContext<MotoAppDbContext>(options => options
.UseSqlServer("Data Source=JAKUB\\SQLEXPRESS02;Initial Catalog=MototoAppStorage;Integreted Security=True"));
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