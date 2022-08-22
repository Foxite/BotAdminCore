namespace FullyDynamicConfigurationInterface;

public class ConsumptionResult {
	public bool IsSuccessful { get; }
	public string? Message { get; }
	public object? ExtraData { get; }

	public ConsumptionResult(bool isSuccessful, string? message = null, object? extraData = null) {
		IsSuccessful = isSuccessful;
		Message = message;
		ExtraData = extraData;
	}
}
