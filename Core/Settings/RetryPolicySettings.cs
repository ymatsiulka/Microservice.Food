namespace Microservice.Food.Core.Settings;

public class RetryPolicySettings
{
    public required int RetriesCount { get; init; }
    public required int MedianRetryDelay { get; init; }
}