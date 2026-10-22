namespace ContractWatcher.TestApi.Contracts;

public sealed class CreateUserRequest
{
    public required string Email { get; init; }

    public required string Name { get; init; }

    public int Age { get; init; }

    public bool IsActive { get; init; }
}