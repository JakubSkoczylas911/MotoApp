namespace MotoApp;
using System.Xml.Linq;
using MotoApp.Components.CsvReader;
using MotoApp.Data;

public class App : IApp
{
    private readonly ICsvReader _csvReader;
    private readonly MotoAppDbContext _motoAppDbContext;
    public App(ICsvReader csvReader, MotoAppDbContext motoAppDbContext)
    {
        _csvReader = csvReader;
        _motoAppDbContext = motoAppDbContext;
        _motoAppDbContext.Database.EnsureCreated();
    }
    public void Run()
    {
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
    }


    //}
    //private static void QueryXml()
    //{
    //    var document = XDocument.Load("fuel.xml");
    //    var names = document
    //        .Element("Cars")?
    //        .Elements("Car")
    //        .Where(x => x.Attribute("Manufacturer")?.Value == "BMW")
    //        .Select(x => x.Attribute("Name")?.Value);
    //    foreach (var name in names)
    //    {
    //        Console.WriteLine(name);
    //    }
    //}

    //private void CreateXml()
    //{
    //    var records = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
    //    var document = new XDocument();
    //    var cars = new XElement("Cars", records
    //        .Select(x =>
    //        new XElement("Car",
    //        new XAttribute("Name", x.Name),
    //        new XAttribute("Combined", x.Combined),
    //        new XAttribute("Manufacturer", x.Manufacturer))));
    //    document.Add(cars);
    //    document.Save("fuel.xml");
    //}
}

//        var manufacturers = _csvReader.ProcessManufactures("Resources\\Files\\manufacturers.csv");
//        var groups = manufacturers.GroupJoin(
//            cars,
//            manufacturer => manufacturer.Name,
//            car => car.Manufacturer,
//            (m, g) =>
//            new
//            {
//                Manufacturer = m,
//                Cars = g
//            })
//            .OrderBy(x => x.Manufacturer.Name);
//        foreach (var car in groups)
//        {
//            Console.WriteLine($"Manufacturer:{car.Manufacturer.Name}");
//            Console.WriteLine($"Cars:{car.Cars.Count()}");
//            Console.WriteLine($"Max:{car.Cars.Max(x => x.Combined)}");
//            Console.WriteLine($"Min:{car.Cars.Min(x => x.Combined)}");
//            Console.WriteLine($"Avg:{car.Cars.Average(x => x.Combined)}");
//            Console.WriteLine();
//        }
//    }
//}

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


