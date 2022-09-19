﻿using Eschody.Domain.Contracts.Infrascructure.Repositories;
using Eschody.Domain.Contracts.Services;

namespace Eschody.Services.Handlers.Authentication;

public class UserHandler : IHandler<HttpRequestException, HttpResponseMessage>
{
    private readonly IUserRepository _userRepository;

    public UserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public HttpResponseMessage Handle(HttpRequestException request)
    {
        throw new NotImplementedException();
    }
}