using FullyDynamicConfigurationInterface;

namespace Demo.BotAdmin; 

public class DemoConfigDto {
	public string Title { get; set; }
	public string Description { get; set; }
	public int Value { get; set; }
}

public class DemoParamsDto : IParamsDto {
	public int Id { get; set; }
}
