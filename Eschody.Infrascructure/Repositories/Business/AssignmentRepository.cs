using Eschody.Domain.Models.DTOs;
using Eschody.Infrascructure.Data;

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
}