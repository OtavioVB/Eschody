using OVB.Project.Eschody.Monolithic.Domain.Base.DataTransferObject;

namespace OVB.Project.Eschody.Monolithic.Infrascructure.Data.Repositories.Base.Interfaces;

public interface IBaseRepository<TEntity>
    where TEntity : DataTransferObjectBase
{
    Task AddAsync(TEntity entity);
    Task<List<TEntity>> GetEntitiesByPaginationAsync(int index, int offset);
    Task<TEntity?> GetEntityByIdentifierAsync(Guid identifier);
    Task UpdateAsync(TEntity entity);
}
