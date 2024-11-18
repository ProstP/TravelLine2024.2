namespace Application.UseCases.User.Command.UpdateUserCommand;

public class UpdateUserCommand
{
    public string OldLogin { get; init; }

    public string Name { get; init; }
    public string Login { get; init; }
    public string Password { get; init; }
    public string About { get; init; }
}
