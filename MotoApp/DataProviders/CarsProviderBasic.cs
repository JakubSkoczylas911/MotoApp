using MotoApp.Repositories;

namespace MotoApp.DataProviders;

public class CarsProviderBasic : ICarsProvider
{
    private readonly IRepository<Car> _carsRepository;
    public CarsProviderBasic(IRepository<Car> carsRepository)
    {
        _carsRepository = carsRepository;
    }
    List<Car> ICarsProvider.FilterCars(decimal minPrice)
    {
        var cars = _carsRepository.GetAll();
        var list = new List<Car>();
        foreach (var car in cars)
        {
            if (car.ListPrice > minPrice)
            {
                list.Add(car);
            }
        }
        return list;
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

