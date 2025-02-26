namespace MotoApp.Components.CsvReader;
using MotoApp.Components.CsvReader.Extensions;
using MotoApp.Components.CsvReader.Models;
public interface ICsvReader
{
    List<Car> ProcessCars(string filePath);
    List<Manufacturer> ProcessManufactures(string filePath);

}
