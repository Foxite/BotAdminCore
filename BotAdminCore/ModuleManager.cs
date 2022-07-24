using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BotAdminCore; 

public sealed class ModuleManager {
	private readonly List<Module> m_Modules;

	internal ModuleManager() {
		m_Modules = new List<Module>();
	}

	internal void SetupModules(WebApplicationBuilder applicationBuilder, IMvcBuilder mvcBuilder) {
		IEnumerable<Assembly> assemblies = LoadAssemblies();
		ICollection<Type> types = FindModuleClasses(assemblies);

		foreach (Type type in types) {
			var module = (Activator.CreateInstance(type) as Module)!; // Can technically be null but should never happen.
			m_Modules.Add(module);
		}

		foreach (Module module in m_Modules) {
			module.Startup(applicationBuilder);
		}

		foreach (Module module in m_Modules) {
			mvcBuilder.AddApplicationPart(module.GetType().Assembly);
		}
	}

	private static IList<Assembly> LoadAssemblies() {
		var assemblies = new List<Assembly>();
		foreach (DirectoryInfo moduleDirectory in new DirectoryInfo(Path.Combine(AppContext.BaseDirectory, "Modules")).EnumerateDirectories()) {
			string path = Path.Combine(moduleDirectory.FullName, moduleDirectory.Name + ".dll");

			if (File.Exists(path)) {
				var assembly = Assembly.LoadFrom(path);
				assemblies.Add(assembly);
			} else {
				throw new InvalidOperationException("Module directory " + moduleDirectory.FullName + " does not contain a valid module assembly");
			}
		}
		return assemblies;
	}

	private static IList<Type> FindModuleClasses(IEnumerable<Assembly> assemblies) {
		return (
			from domainAssembly in assemblies
			from assemblyType in domainAssembly.GetExportedTypes()
			where assemblyType.IsSubclassOf(typeof(Module))
			select assemblyType
		).ToArray();
	}

	public IReadOnlyList<Module> GetModules() {
		return m_Modules.AsReadOnly();
	}
}