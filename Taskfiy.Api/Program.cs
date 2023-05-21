//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Taskfiy.Api.ExceptionHandler;
using Taskify.Application;
using Taskify.Infrastructure;

namespace Taskfiy.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			Log.Logger = new LoggerConfiguration()
				.Enrich.FromLogContext()
				.ReadFrom.Configuration(builder.Configuration)
				.CreateLogger();

			builder.Services.AddApplication();
			builder.Services.AddInfrastructure(builder.Configuration);

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();
			app.UseGlobalExceptionHandlerMiddleware();

			app.MapControllers();

			app.Run();
		}
	}
}