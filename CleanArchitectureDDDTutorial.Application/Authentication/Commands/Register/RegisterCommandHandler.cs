﻿using CleanArchitectureDDDTutorial.Application.Authentication.Commands.Common;
using CleanArchitectureDDDTutorial.Application.Common.Interfaces.Authentication;
using CleanArchitectureDDDTutorial.Application.Common.Interfaces.Persistence;
using CleanArchitectureDDDTutorial.Domain.Common.Errors;
using CleanArchitectureDDDTutorial.Domain.Entities;
using ErrorOr;
using MediatR;

namespace CleanArchitectureDDDTutorial.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(command.Email) is not null)
            return Errors.User.DuplicateEmail;

        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
