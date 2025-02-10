namespace MotoApp.Components.DataProviders;

public interface ICarsProvider
{
    List<Car> FilterCars(decimal minPrice);
    List<string> GetUniqueCarColors();
    decimal GetMinimumPriceOfAllCars();
}
