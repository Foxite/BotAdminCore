using System.Net;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Demo.BotAdmin;

[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase {
	private readonly ILogger<DemoController> m_Logger;

	public DemoController(ILogger<DemoController> logger) {
		m_Logger = logger;
	}

	[HttpGet("demo")]
	public string DemoEndpoint() {
		return "The presence of this endpoint shows that the module system is working correctly.";
	}

	/*
	[HttpGet("TestForm")]
	public FormGroup GetTestForm() {
		return new FormGroup("Test form",
			new FormField("Test field 1", FormFieldType.Text),
			new FormField("Test field 2", FormFieldType.Text, new Regex(@"(hello|goodbye)", RegexOptions.IgnoreCase)),
			new FormField("Test field 3", FormFieldType.Number),
			new FormField("Test field 4", FormFieldType.Number, new { Min = 0, Max = 10 }),
			new FormField("Test field 5", FormFieldType.Options, new[] { "Option A", "Option B", "Option C" })
		);
	}

	[HttpPost("TestForm")]
	public IActionResult PostTestForm(TestFormModel model) {
		m_Logger.LogInformation(JsonConvert.SerializeObject(model));
		return StatusCode((int) HttpStatusCode.NotImplemented);
	}
	
	public class TestFormModel {
		public string Testfield1 { get; set; }
		public string Testfield2 { get; set; }
		public int Testfield3 { get; set; }
		public int Testfield4 { get; set; }
		public string[] Testfield5 { get; set; }
	}*/
}
