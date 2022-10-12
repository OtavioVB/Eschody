using Eschody.Domain.Conctracts.Infrascructure.Repository;
using Eschody.Domain.Conctracts.Services;
using Flunt.Notifications;

namespace Eschody.Services.Handlers.Authentication.Login;

public class HandlerLoginStudentAccount : Notifiable, IHandler<ResponseLoginStudentAccount, RequestLoginStudentAccount>
{
    private readonly IUserRepository _userRepository;

    public HandlerLoginStudentAccount(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<ResponseLoginStudentAccount> Handle(RequestLoginStudentAccount request)
    {
        throw new NotImplementedException();
    }
}
