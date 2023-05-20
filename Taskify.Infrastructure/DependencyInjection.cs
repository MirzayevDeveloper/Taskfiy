//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taskify.Application.Abstractions;
using Taskify.Infrastructure.Mapping;
using Taskify.Infrastructure.Persistence;

namespace Taskify.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
			{
				options.UseNpgsql(connectionString: configuration.GetConnectionString("TaskifyDbConnection"));
			});

			services.AddAutoMapper(typeof(MappingProfile));

			return services;
		}
	}
}