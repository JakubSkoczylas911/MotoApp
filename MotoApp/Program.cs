using MotoApp.Entities;
using MotoApp.Repositories;
var employeeRepository = new GenericRepository<Employee>();
employeeRepository.Add(new Employee { FirstName = "Adam" });
employeeRepository.Add(new Employee { FirstName = "Piotr" });
employeeRepository.Add(new Employee { FirstName = "Zuzia" });
employeeRepository.Save();