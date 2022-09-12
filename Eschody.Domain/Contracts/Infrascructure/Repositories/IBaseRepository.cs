namespace Eschody.Domain.Contracts.Infrascructure.Repositories;

public interface IBaseRepository<T> where T : class
{
    public Task InsertAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(T entity);
    public Task<T?> GetByIdAsync(int id);
}
