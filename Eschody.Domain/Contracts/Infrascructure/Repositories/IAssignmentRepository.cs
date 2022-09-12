using Eschody.Domain.Models.DTOs;

namespace Eschody.Domain.Contracts.Infrascructure.Repositories;

public interface IAssignmentRepository : IBaseRepository<Assignment>
{
    public Task<List<Assignment>> GetAssignmentsAsync(Guid userId);
}
