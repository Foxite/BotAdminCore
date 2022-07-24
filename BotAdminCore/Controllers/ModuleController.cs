using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BotAdminCore.Controllers;

[ApiController]
[Route("[controller]")]
public class ModuleController : ControllerBase {
	private readonly ILogger<ModuleController> m_Logger;
	private readonly ModuleManager m_ModuleManager;

	public ModuleController(ILogger<ModuleController> logger, ModuleManager moduleManager) {
		m_Logger = logger;
		m_ModuleManager = moduleManager;
	}

	[HttpGet]
	public IReadOnlyList<string> GetModules() {
		return m_ModuleManager.GetModules().ListSelect(module => module.Name);
	}
}
