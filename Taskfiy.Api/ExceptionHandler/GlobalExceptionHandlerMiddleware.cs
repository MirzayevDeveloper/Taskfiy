//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Taskfiy.Api.ExceptionHandler
{
	public class GlobalExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;

		public GlobalExceptionHandlerMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public Task Invoke(HttpContext httpContext)
		{
			try
			{
				return _next(httpContext);
			}
			catch (Exception exception)
			{

				throw;
			}
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
