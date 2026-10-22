namespace ContractWatcher.TestApi.Contracts;

public sealed class CreateOrderRequest
{
    public required string ProductId { get; init; }

    public required int Quantity { get; init; }

    public string? Comment { get; init; }
}