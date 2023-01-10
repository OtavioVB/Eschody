using OVB.Project.Eschody.Monolithic.Domain.AssignmentContext.DataTransferObject;
using OVB.Project.Eschody.Monolithic.Infrascructure.Data.Repositories.Base;

namespace OVB.Project.Eschody.Monolithic.Infrascructure.Data.Repositories;

public sealed class AssignmentRepository : BaseRepository<Assignment>
{
    public AssignmentRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
