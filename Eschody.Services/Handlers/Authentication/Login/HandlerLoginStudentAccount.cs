using Eschody.Domain.Contracts.Infrascructure.Repository;
using Eschody.Domain.Contracts.Services.Handlers;
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
