﻿namespace Application.Users.Command.CreateUserCommand;

public class CreateUserCommand
{
    public string Login { get; init; }
    public string PasswordHash { get; init; }
}
