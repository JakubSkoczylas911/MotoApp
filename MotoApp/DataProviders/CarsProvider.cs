﻿
using System.Text;
using MotoApp.DataProviders.Extensions;
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
        var cars = _carsRepository.GetAll();
        return cars.Select(x => x.ListPrice).Min();
    }
    public List<Car> GetSpecificColumns()
    {
        var cars = _carsRepository.GetAll();
        var list = cars.Select(car => new Car
        {
            Id = car.Id,
            Name = car.Name,
            Type = car.Type
        }).ToList();
        return list;
    }
    public string AnonymousClass()
    {
        var cars = _carsRepository.GetAll();
        var list = cars.Select(car => new
        {
            Identifier = car.Id,
            ProductName = car.Name,
            ProductType = car.Type
        });
        StringBuilder sb = new(2048);
        foreach (var car in list)
        {
            sb.AppendLine($"Product ID:{car.Identifier}");
            sb.AppendLine($"Product Name:{car.ProductName}");
            sb.AppendLine($"Product Type:{car.ProductType}");
        }
        return sb.ToString();
    }
    public List<Car> OrderByName()
    {
        var cars = _carsRepository.GetAll();


        return cars.OrderBy(x => x.Name).ToList();
    }

    public List<Car> OrderByNameDescending()
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderByDescending(x => x.Name).ToList();
    }

    public List<Car> OrderByColorAndName()
    {
        var cars = _carsRepository.GetAll();
        return cars
            .OrderBy(x => x.Color)
            .ThenBy(x => x.Name)
            .ToList();
    }
    public List<Car> OrderByColorAndNameDesc()
    {
        var cars = _carsRepository.GetAll();
        return cars
            .OrderByDescending(x => x.Color)
            .ThenByDescending(x => x.Name)
            .ToList();
    }
    public List<Car> WhereStartsWith(string prefix)
    {
        var cars = _carsRepository.GetAll();
        return cars.Where(x => x.Name.StartsWith(prefix)).ToList();
    }
    public List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost)
    {
        var cars = _carsRepository.GetAll();
        return cars.Where(x => x.Name.StartsWith(prefix) && x.StandardCost > cost).ToList();
    }
    public List<Car> WhereColorIs(string color)
    {
        var cars = _carsRepository.GetAll();
        return cars.ByColor("Red").ToList();
    }

    public List<string> GetUniqueCarColors()
    {
        var cars = _carsRepository.GetAll();
        var colors = cars.Select(x => x.Color).Distinct().ToList();
        return colors;
        throw new NotImplementedException();
    }
}
