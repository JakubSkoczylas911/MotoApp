
using MotoApp.Repositories;

namespace MotoApp.DataProviders;
public class CarsProvider : ICarsProvider
{
    private readonly IRepository<Car> _carsRepository;
    public CarsProvider(IRepository<Car> carsRepository)
    {
        _carsRepository = carsRepository;
    }
    public List<Car> FilterCars(decimal minPrice)
    {
        throw new NotImplementedException();
    }

    public decimal GetMinimumPriceOfAllCars()
    {
        throw new NotImplementedException();
    }

    public List<string> GetUniqueCarColors()
    {
        var cars = _carsRepository.GetAll();
        var colors = cars.Select(x => x.Color).Distinct().ToList();
        return colors;
        throw new NotImplementedException();
    }
}
