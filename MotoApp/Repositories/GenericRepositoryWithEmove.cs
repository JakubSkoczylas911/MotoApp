namespace MotoApp.Repositories;
using MotoApp.Entities;

public  class GenericRepositoryWithEmove<T>:GenericRepository<T>where T: IEntity
{
    public void Remove(T item)
    {
    _items.Remove(item);
}
}

