using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.BotAdmin;

[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase {
	private readonly ILogger<DemoController> m_Logger;

	public DemoController(ILogger<DemoController> logger) {
		m_Logger = logger;
	}

	[HttpGet]
	public string Get() {
		m_Logger.LogInformation("hello!");
		return "hello!";
	}
}
