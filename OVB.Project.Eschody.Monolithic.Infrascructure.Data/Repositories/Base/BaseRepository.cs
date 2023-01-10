using Microsoft.EntityFrameworkCore;
using OVB.Project.Eschody.Monolithic.Domain.Base.DataTransferObject;
using OVB.Project.Eschody.Monolithic.Infrascructure.Data.Repositories.Base.Interfaces;

namespace OVB.Project.Eschody.Monolithic.Infrascructure.Data.Repositories.Base;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : DataTransferObjectBase
{
    protected readonly DataContext _dataContext;

    protected BaseRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dataContext.Set<TEntity>().AddAsync(entity);
    }

    public async Task<List<TEntity>> GetEntitiesByPaginationAsync(int index, int offset)
    {
        return await _dataContext.Set<TEntity>().Take(index).Skip(offset).ToListAsync();
    }

    public Task<TEntity?> GetEntityByIdentifierAsync(Guid identifier)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
