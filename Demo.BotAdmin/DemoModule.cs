using BotAdminCore;

namespace Demo.BotAdmin;

public class DemoModule : Module {
	public override string Name => "Demo Module";
	
	public override void Startup(WebApplicationBuilder applicationBuilder) {
		Console.WriteLine("hello!");
	}
}
