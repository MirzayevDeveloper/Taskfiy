//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Taskify.Application.UseCases.Permissions.Exceptions;
using Taskify.Application.UseCases.Roles.Exceptions;
using Taskify.Application.UseCases.Roles.Models;
using Xeptions;

namespace Taskify.Application.UseCases.Roles.Validations
{
	public static class RoleExceptionHandler
	{
		public delegate Task<RoleDto> ReturningRoleFunction();
		public delegate IQueryable<GetRolesDto> ReturningRolesFunction();

		public static async Task<RoleDto> TryCatch(ReturningRoleFunction returningRoleFunction)
		{
			try
			{
				return await returningRoleFunction();
			}
			catch (NullRoleException nullRoleException)
			{
				throw CreateValidationException(nullRoleException);
			}
			catch (InvalidRoleException invalidRoleException)
			{
				throw CreateValidationException(invalidRoleException);
			}
			catch (NotFoundRoleException notFoundRoleException)
			{
				throw CreateValidationException(notFoundRoleException);
			}
			catch (PostgresException postgresException)
			{
				var failedRoleStorageException =
					new FailedRoleStorageException(postgresException);

				throw CreateFatalDependencyException(failedRoleStorageException);
			}
			catch (DbUpdateException dbUpdateException)
				when (dbUpdateException.InnerException.Message.Contains("23505"))
			{
				var alreadyExistsRoleException =
					new AlreadyExistsRoleException(dbUpdateException);

				throw CreateAndDependencyValidationException(alreadyExistsRoleException);
			}
			catch (DbUpdateException dbUpdateException)
			{
				var failedRoleStorageException =
					new FailedRoleStorageException(dbUpdateException);

				throw CreateFatalDependencyException(failedRoleStorageException);
			}
			catch (Exception serviceException)
			{
				var failedRoleServiceException =
					new FailedRoleServiceException(serviceException);

				throw CreateServiceException(failedRoleServiceException);
			}
		}

		public static IQueryable<GetRolesDto> TryCatch(ReturningRolesFunction returningRolesFunction)
		{
			try
			{
				return returningRolesFunction().AsQueryable();
			}
			catch (PostgresException postgresException)
			{
				var failedRoleStorageException =
					new FailedRoleStorageException(postgresException);

				throw CreateFatalDependencyException(failedRoleStorageException);
			}
			catch (DbUpdateException dbUpdateException)
			{
				var failedRoleStorageException =
					new FailedRoleStorageException(dbUpdateException);

				throw CreateFatalDependencyException(failedRoleStorageException);
			}
			catch (Exception serviceException)
			{
				var failedRoleServiceException =
					new FailedRoleServiceException(serviceException);

				throw CreateServiceException(failedRoleServiceException);
			}
		}

		private static RoleServiceException CreateServiceException(Exception exception) =>
			new RoleServiceException(exception);

		private static RoleDependencyValidationException CreateAndDependencyValidationException(Xeption exception) =>
			new RoleDependencyValidationException(exception);

		private static RoleValidationException CreateValidationException(Xeption exception) =>
			new RoleValidationException(exception);

		private static PermissionDependencyException CreateFatalDependencyException(Xeption exception) =>
			new PermissionDependencyException(exception);
	}
}
