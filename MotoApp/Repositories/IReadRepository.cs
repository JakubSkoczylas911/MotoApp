namespace MotoApp.Repositories;
using MotoApp.Entities;

public interface IReadRepository<out T> where T : class, IEntity

{
    IEnumerable<T> GetAll();
    T GetbyId(int id);
}
