using Eschody.Domain.Models.DTOs;
using Eschody.Infrascructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Eschody.Infrascructure.Repositories.Business;

public class AssignmentRepository
{
    private readonly DataContext _dataContext;

    public AssignmentRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    /// <summary>
    /// Inserir uma nova tarefa no banco de dados
    /// </summary>
    /// <param name="assignment">Assignment Entity</param>
    public async Task InsertNewAssignment(Assignment assignment)
    {
        await _dataContext.Assignments.AddAsync(assignment);
        await _dataContext.SaveChangesAsync();
    }

    /// <summary>
    /// Obter todas as tarefas de um usuário
    /// </summary>
    /// <param name="userIdentifier">Identificador do Usuário</param>
    public async Task<List<Assignment>> GetAssignmentsAsync(Guid userIdentifier)
    {
        return await _dataContext.Assignments.AsNoTracking().Include("User").Where(p => p.User.Identifier == userIdentifier).ToListAsync();
    }

    /// <summary>
    /// Obter as informações de uma tarefa
    /// </summary>
    /// <param name="assignmnetIdentifier">Identificador da tarefa</param>
    public async Task<Assignment?> GetAssignmentAsync(Guid assignmnetIdentifier)
    {
        return await _dataContext.Assignments.Where(p => p.Identifier == assignmnetIdentifier).FirstOrDefaultAsync();
    }

    /// <summary>
    /// Obter a lista de tarefas que ainda não foram feitas
    /// </summary>
    public async Task<List<Assignment>> GetAssignmentsNotDoneAsync(Guid userIdentifier)
    {
        return await _dataContext.Assignments.AsNoTracking().Include("User").Where(p => p.User.Identifier == userIdentifier && p.Done == false).ToListAsync();
    }

    /// <summary>
    /// Obter a lista de tarefas que foram realizadas
    /// </summary>
    public async Task<List<Assignment>> GetAssignmentsDoneAsync(Guid userIdentifier)
    {
        return await _dataContext.Assignments.AsNoTracking().Include("User").Where(p => p.User.Identifier == userIdentifier && p.Done == true).ToListAsync();
    }
}