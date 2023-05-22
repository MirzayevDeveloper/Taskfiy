//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Serilog;
using Taskify.Application.UseCases.Permissions.Exceptions;
using Taskify.Application.UseCases.Roles.Exceptions;

namespace Taskfiy.Api.ExceptionHandler
{
	public partial class GlobalExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;

		public GlobalExceptionHandlerMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			var controllerName = httpContext.GetRouteData()
				.Values["controller"]?.ToString().ToLower();

			switch (controllerName)
			{
				case "permissions":
					{
						try
						{
							await _next(httpContext);
						}
						catch (PermissionValidationException permissionValidationException)
						{
							httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

							Logger(status: LogStatus.Error,
									exception: permissionValidationException,
									message: permissionValidationException.Message);

							await ExceptionHandler(httpContext, permissionValidationException);
						}
						catch (PermissionDependencyValidationException permissionDependencyValidationException)
							when (permissionDependencyValidationException.InnerException
										is AlreadyExistsPermissionException)
						{
							httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;

							Logger(status: LogStatus.Error,
									exception: permissionDependencyValidationException,
									message: permissionDependencyValidationException.Message);

							await ExceptionHandler(httpContext, permissionDependencyValidationException);
						}
						catch (PermissionDependencyValidationException permissionDependencyValidationException)
						{
							httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

							Logger(status: LogStatus.Error,
									exception: permissionDependencyValidationException,
									message: permissionDependencyValidationException.Message);

							await ExceptionHandler(httpContext, permissionDependencyValidationException);
						}
						catch (PermissionDependencyException permissionDependencyException)
						{
							httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

							Logger(status: LogStatus.Fatal,
									exception: permissionDependencyException,
									message: permissionDependencyException.Message);

							await ExceptionHandler(httpContext, permissionDependencyException);
						}
						catch (PermissionServiceException permissionServiceException)
						{
							httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

							Logger(status: LogStatus.Fatal,
									exception: permissionServiceException,
									message: permissionServiceException.Message);

							await ExceptionHandler(httpContext, permissionServiceException);
						}
						finally
						{
							Log.CloseAndFlush();
						}
					}
					break;
				case "roles":
					{
						try
						{
							await _next(httpContext);
						}
						catch (RoleValidationException roleValidationException)
						{
							httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

							Logger(status: LogStatus.Error,
									exception: roleValidationException,
									message: roleValidationException.Message);

							await ExceptionHandler(httpContext, roleValidationException);
						}
						catch (RoleDependencyValidationException roleDependencyValidationException)
							when (roleDependencyValidationException.InnerException
										is AlreadyExistsRoleException)
						{
							httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;

							Logger(status: LogStatus.Error,
									exception: roleDependencyValidationException,
									message: roleDependencyValidationException.Message);

							await ExceptionHandler(httpContext, roleDependencyValidationException);
						}
						catch (RoleDependencyValidationException roleDependencyValidationException)
						{
							httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

							Logger(status: LogStatus.Error,
									exception: roleDependencyValidationException,
									message: roleDependencyValidationException.Message);

							await ExceptionHandler(httpContext, roleDependencyValidationException);
						}
						catch (RoleDependencyException roleDependencyException)
						{
							httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

							Logger(status: LogStatus.Fatal,
									exception: roleDependencyException,
									message: roleDependencyException.Message);

							await ExceptionHandler(httpContext, roleDependencyException);
						}
						catch (RoleServiceException roleServiceException)
						{
							httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

							Logger(status: LogStatus.Fatal,
									exception: roleServiceException,
									message: roleServiceException.Message);

							await ExceptionHandler(httpContext, roleServiceException);
						}
						finally
						{
							Log.CloseAndFlush();
						}
					}
					break;
			}
		}
	}
}
