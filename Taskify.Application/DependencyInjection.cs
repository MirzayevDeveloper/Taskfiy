using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Taskify.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddMediatR(conf =>
				conf.RegisterServicesFromAssemblies(
					assemblies: Assembly.GetExecutingAssembly()));

			return services;
		}
	}
}