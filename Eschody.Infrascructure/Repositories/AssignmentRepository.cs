using Eschody.Domain.Contracts.Infrascructure.Repositories;
using Eschody.Domain.Models.DTOs;
using Eschody.Infrascructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Eschody.Infrascructure.Repositories;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly DataContext _dataContext;

    public AssignmentRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    /// <summary>
    /// Adicionar novas tarefas do usuário de modo assíncrono
    /// </summary>
    /// <param name="assignment">Tarefa do Usuário</param>
    /// <returns>Validar todos os campos</returns>
    public async Task InsertNewAssingmentAsync(Assignment assignment)
    {
        await _dataContext.AddAsync(assignment);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteAssignmentAsync(Assignment assignment)
    {
        _dataContext.Assignments.Remove(assignment);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<Assignment?> GetAssignmentAsync(int id)
    {
        var assignment = await _dataContext.Assignments.FindAsync(id);

        if (assignment != null)
        {
            return assignment;
        }
        else
        {
            return null;
        }
    }

    public async Task<List<Assignment>> GetAssignmentsAsync(Guid userId)
    {
        var assignment = await _dataContext.Assignments.Where(p => p.IdentifierUser == userId).ToListAsync();
        return assignment;
    }

    public async Task UpdateAssignmentAsync(Assignment assignment)
    {
        _dataContext.Assignments.Update(assignment);
        await _dataContext.SaveChangesAsync();
    }
}
