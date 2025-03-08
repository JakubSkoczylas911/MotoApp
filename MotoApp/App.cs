﻿namespace MotoApp;
using MotoApp.Components.CsvReader;
using MotoApp.Components.CsvReader.Models;

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
        var groups = manufacturers.GroupJoin(
            cars,
            manufacturer => manufacturer.Name,
            car => car.Manufacturer,
            (m, g) =>
            new
            {
                Manufacturer = m,
                Cars = g
            })
            .OrderBy(x => x.Manufacturer.Name);
        foreach (var car in groups)
        {
            Console.WriteLine($"Manufacturer:{car.Manufacturer.Name}");
            Console.WriteLine($"Cars:{car.Cars.Count()}");
            Console.WriteLine($"Max:{car.Cars.Max(x => x.Combined)}");
            Console.WriteLine($"Min:{car.Cars.Min(x => x.Combined)}");
            Console.WriteLine($"Avg:{car.Cars.Average(x => x.Combined)}");
            Console.WriteLine();
        }
    }
}

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
//        var carsInCountry = cars.Join(manufacturers,
//            c => new { c.Manufacturer, c.Year },
//            m => new { Manufacturer = m.Name, m.Year },
//            (car, manufacturer) =>
//            new
//            {
//                manufacturer.Country,
//                car.Name,
//                car.Combined
//            })
//            .OrderByDescending(x => x.Combined)
//            .ThenBy(x => x.Name);
//        foreach (var car in carsInCountry)
//        {
//            Console.WriteLine($"Country:{car.Country}");
//            Console.WriteLine($"Name:{car.Name}");
//            Console.WriteLine($"Combined:{car.Combined}");
//        }
//    }
//}


