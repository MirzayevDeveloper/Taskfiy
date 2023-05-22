//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace Taskfiy.Api.ExceptionHandler
{
	public partial class GlobalExceptionHandlerMiddleware
	{
		private static void Logger(Exception exception, string message, LogStatus status)
		{
			switch (status)
			{
				case LogStatus.Error: Log.Error(message, exception); break;
				case LogStatus.Fatal: Log.Fatal(message, exception); break;
			}
		}

		private static async Task ExceptionHandler(HttpContext httpContext, Exception exception)
		{
			httpContext.Response.ContentType = "application/json";

			var errorResponse = new
			{
				StatusCode = httpContext.Response.StatusCode,
				Message = exception.InnerException.Message
			};

			var json = JsonConvert.SerializeObject(errorResponse);

			await httpContext.Response.WriteAsync(json);
		}
	}

	public static class GlobalExceptionHandlerMiddlewareExtensions
	{
		public static IApplicationBuilder UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
		}
	}
}
