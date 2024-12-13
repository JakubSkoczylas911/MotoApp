using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Repositories;
using MotoApp.Repositories.Extensions;

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
AddEmployees(employeeRepository);
WriteAllToConsole(employeeRepository);
static void AddEmployees(IRepository<BusinessPartner> businessPartnerRepository)
{
    var bussinessPartners = new[]
    {
        new BusinessPartner {},
        new BusinessPartner { },
        new BusinessPartner { },
    };
    businessPartnerRepository.AddBatch(bussinessPartners);
    //    AddBatch(employeeRepository, employees);
    //}
    //static void AddBatch<T>(IRepository<T> repository, T[] items)
    //    where T : class, IEntity
    //{
    //    foreach (var item in items)
    //    {
    //        repository.Add(item);
    //    }
    //    repository.Save();
    //}
    static void WriteAllToConsole(IReadRepository<IEntity> repository)
    {
        var items = repository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}