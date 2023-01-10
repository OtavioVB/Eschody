using OVB.Project.Eschody.Monolithic.Domain.AccountContext.DataTransferObject;
using OVB.Project.Eschody.Monolithic.Infrascructure.Data.Repositories.Base;

namespace OVB.Project.Eschody.Monolithic.Infrascructure.Data.Repositories;

public class AccountRepository : BaseRepository<Account>
{
    public AccountRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
