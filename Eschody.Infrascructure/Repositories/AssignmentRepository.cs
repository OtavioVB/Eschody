using Eschody.Domain.Contracts.Infrascructure.Repositories;
using Eschody.Domain.Models.DTOs;
using Eschody.Infrascructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Eschody.Infrascructure.Repositories;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly EschodyApplicationContext _dbContext;

    public AssignmentRepository(EschodyApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task InsertNewAssingmentAsync(Assignment assignment)
    {
        await _dbContext.AddAsync(assignment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAssignmentAsync(Assignment assignment)
    {
        _dbContext.Assignments.Remove(assignment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Assignment?> GetAssignmentAsync(int id)
    {
        var assignment = await _dbContext.Assignments.FindAsync(id);

        if (assignment != null)
        {
            return assignment;
        }
        else
        {
            return null;
        }
    }

    public List<Assignment> GetAssignmentsAsync(int userId)
    {
        var assingment = _dbContext.Assignments.Where(p => p.IdentifierUser == userId).ToList();
        return assingment;
    }

    public async Task UpdateAssignmentAsync(Assignment assignment)
    {
        _dbContext.Assignments.Update(assignment);
        await _dbContext.SaveChangesAsync();
    }
}
