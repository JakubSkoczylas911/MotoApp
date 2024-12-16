namespace MotoApp.Repositories.Extensions;
using MotoApp.Entities;


public static class RepositoryExtensions
{
    public static void AddBatch<T>(this IRepository<T> repository, T[] items)
    where T : class, IEntity
    {
        foreach (var employee in items)
        {
            repository.Add(employee);
        }
        repository.Save();
    }
}
