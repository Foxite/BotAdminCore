using BotAdminCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var moduleManager = new ModuleManager();
builder.Services.AddSingleton(moduleManager);

IMvcBuilder mvcBuilder = builder.Services.AddControllers();
moduleManager.SetupModules(builder, mvcBuilder);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


WebApplication app = builder.Build();

if (true || app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
