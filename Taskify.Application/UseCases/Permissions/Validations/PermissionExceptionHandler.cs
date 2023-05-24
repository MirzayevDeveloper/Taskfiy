//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Taskify.Application.UseCases.Permissions.Exceptions;
using Taskify.Application.UseCases.Permissions.Models;
using Xeptions;

namespace Taskify.Application.UseCases.Permissions.Validations
{
	public static class PermissionExceptionHandler
	{
		public delegate Task<PermissionDto> ReturningPermissionFunction();
		public delegate IQueryable<GetPermissionsDto> ReturningPermissionsFunction();

		public static async Task<PermissionDto> TryCatch(ReturningPermissionFunction returningPermissionFunction)
		{
			try
			{
				return await returningPermissionFunction();
			}
			catch (NullPermissionException nullPermissionException)
			{
				throw CreateValidationException(nullPermissionException);
			}
			catch (InvalidPermissionException invalidPermissionException)
			{
				throw CreateValidationException(invalidPermissionException);
			}
			catch (NotFoundPermissionException notFoundPermissionException)
			{
				throw CreateValidationException(notFoundPermissionException);
			}
			catch (PostgresException postgresException)
			{
				var failedPermissionStorageException =
					new FailedPermissionStorageException(postgresException);

				throw CreateFatalDependencyException(failedPermissionStorageException);
			}
			catch (DbUpdateException dbUpdateException)
				when (dbUpdateException.InnerException.Message.Contains("23505"))
			{
				var alreadyExistsPermissionException =
					new AlreadyExistsPermissionException(dbUpdateException);

				throw CreateAndDependencyValidationException(alreadyExistsPermissionException);
			}
			catch (DbUpdateException dbUpdateException)
			{
				var failedPermissionStorageException =
					new FailedPermissionStorageException(dbUpdateException);

				throw CreateFatalDependencyException(failedPermissionStorageException);
			}
			catch (Exception serviceException)
			{
				var failedPermissionServiceException =
					new FailedPermissionServiceException(serviceException);

				throw CreateServiceException(failedPermissionServiceException);
			}
		}

		public static IQueryable<GetPermissionsDto> TryCatch(ReturningPermissionsFunction returningPermissionsFunction)
		{
			try
			{
				return returningPermissionsFunction().AsQueryable();
			}
			catch (PostgresException postgresException)
			{
				var failedPermissionStorageException =
					new FailedPermissionStorageException(postgresException);

				throw CreateFatalDependencyException(failedPermissionStorageException);
			}
			catch (DbUpdateException dbUpdateException)
			{
				var failedPermissionStorageException =
					new FailedPermissionStorageException(dbUpdateException);

				throw CreateFatalDependencyException(failedPermissionStorageException);
			}
			catch (Exception serviceException)
			{
				var failedPermissionServiceException =
					new FailedPermissionServiceException(serviceException);

				throw CreateServiceException(failedPermissionServiceException);
			}
		}

		private static PermissionDependencyValidationException CreateAndDependencyValidationException(Xeption exception)
		{
			var permissionDependencyValidationException =
				new PermissionDependencyValidationException(exception);

			//Log.Error(permissionDependencyValidationException, exception.Message);

			return permissionDependencyValidationException;
		}

		private static PermissionServiceException CreateServiceException(Exception exception)
		{
			var permissionServiceException = new PermissionServiceException(exception);
			//Log.Error(permissionServiceException, exception.Message);

			return permissionServiceException;
		}

		private static PermissionValidationException CreateValidationException(Xeption exception)
		{
			var permissionValidationException = new PermissionValidationException(exception);

			return permissionValidationException;
		}

		private static PermissionDependencyException CreateFatalDependencyException(Xeption exception)
		{
			var permissionDependencyException = new PermissionDependencyException(exception);
			//Log.Fatal(permissionDependencyException, exception.Message);

			return permissionDependencyException;
		}
	}
}
