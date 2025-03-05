namespace MotoApp;
using MotoApp.Components.CsvReader;
public class App : IApp
{
    private readonly ICsvReader _csvReader;
    public App(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }
    public void Run()
    {
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturers = _csvReader.ProcessManufactures("Resources\\Files\\manufacturers.csv");
        //var groups = cars
        //    .GroupBy(x => x.Manufacturer)
        //    .Select(g => new
        //    {
        //        Name = g.Key,
        //        Max = g.Max(cars => cars.Combined),
        //        Average = g.Average(c => c.Combined)
        //    })
        //    .OrderBy(x => x.Average);
        //foreach (var group in groups)
        //{
        //    Console.WriteLine($"{group.Name}");
        //    Console.WriteLine($"Max:{group.Max}");
        //    Console.WriteLine($"Average:{group.Average}");
        //}
        var carsInCountry = cars.Join(manufacturers, x => x.Manufacturer, x => x.Name,
            (car, manufacturer) =>
            new
            {
                manufacturer.Country,
                car.Name,
                car.Combined
            })
            .OrderByDescending(x => x.Combined)
            .ThenBy(x => x.Name);
        foreach (var car in carsInCountry)
        {
            Console.WriteLine($"Country:{car.Country}");
            Console.WriteLine($"Name:{car.Name}");
            Console.WriteLine($"Combined:{car.Combined}");
        }
    }
}


