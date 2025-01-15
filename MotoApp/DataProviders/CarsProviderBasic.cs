
namespace MotoApp.DataProviders;

public class CarsProviderBasic : ICarsProvider
{
    List<Car> ICarsProvider.FilterCars(decimal minPrice)
    {
        throw new NotImplementedException();
    }

    decimal ICarsProvider.GetMinimumPriceOfAllCars()
    {
        throw new NotImplementedException();
    }

    List<string> ICarsProvider.GetUniqueCarColors()
    {
        throw new NotImplementedException();
    }
}

