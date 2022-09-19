using Eschody.Domain.Contracts.Infrascructure.Repositories;
using Eschody.Domain.Contracts.Services;

namespace Eschody.Services.Handlers.Authentication;

public class UserHandler : IHandler<UserRequest, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public UserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public UserResponse Handle(UserRequest request)
    {
        throw new NotImplementedException();
    }
}
