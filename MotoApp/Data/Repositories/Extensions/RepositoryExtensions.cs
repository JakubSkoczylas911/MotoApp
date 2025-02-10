namespace MotoApp.Data.Repositories.Extensions;

using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

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
