using Microsoft.AspNetCore.Builder;

namespace BotAdminCore;

public abstract class Module {
	public abstract string Name { get; }
	
	public abstract void Startup(WebApplicationBuilder applicationBuilder);
}
