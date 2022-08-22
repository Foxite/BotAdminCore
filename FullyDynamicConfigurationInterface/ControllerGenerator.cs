namespace FullyDynamicConfigurationInterface;

public class ConfigDtoManager {
	private List<Type> m_ConfigDtoTypes = new();
	
	public void RegisterConfigDto<T>() where T : ConfigDto {
		m_ConfigDtoTypes.Add(typeof(T));
	}

	internal IReadOnlyList<Type> GetConfigDtoTypes() => m_ConfigDtoTypes;
}

public static class ControllerGeneratorExtensions {
	public static IEndpointRouteBuilder MapConfigControllers(this IEndpointRouteBuilder endpointRouteBuilder) {
		var configDtoManager = endpointRouteBuilder.ServiceProvider.GetRequiredService<ConfigDtoManager>();

		foreach (Type configDtoType in configDtoManager.GetConfigDtoTypes()) {
			// TODO get params type and build url
			// TODO inspect config type and add endpoints
		}

		return endpointRouteBuilder;
	}
}
