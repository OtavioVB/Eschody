using Eschody.Domain.Models.DTOs;

namespace Eschody.Domain.Contracts.Infrascructure.Repositories;

public interface IAssignmentRepository
{
    public Task InsertNewAssingment(Assignment assignment);
    public Task DeleteAssignment(Assignment assignment);
    public Task<Assignment?> GetAssignment(int id);
}
