namespace MotoApp.Repositories;
using MotoApp.Entities;

public  class GenericRepositoryWithRemove<TEntity,TKey>:GenericRepository<TEntity,TKey>where TEntity:IEntity
{
    public void Remove(TEntity item)
    {
    _items.Remove(item);
}
}

