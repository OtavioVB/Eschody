using Eschody.Domain.Models.DTOs;

namespace Eschody.Domain.Contracts.Infrascructure.Repositories;

public interface IAssignmentRepository
{
    public Task InsertNewAssingmentAsync(Assignment assignment);
    public Task DeleteAssignmentAsync(Assignment assignment);
    public Task<Assignment?> GetAssignmentAsync(int id);
    public Task UpdateAssignmentAsync(Assignment assignment);
    public List<Assignment> GetAssignmentsAsync(int userId);
}
