//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Serilog;
using Taskify.Application.UseCases.Permissions.Exceptions;
using Taskify.Application.UseCases.Permissions.Models;
using Xeptions;

namespace Taskify.Application.UseCases.Permissions.Validations
{
	public static class PermissionExceptionHandler
	{
		public delegate Task<PermissionDto> ReturningPermissionFunction();
		public delegate IQueryable<GetAllPermissionDto> ReturningPermissionsFunction();

		public static async Task<PermissionDto> TryCatch(ReturningPermissionFunction returningPermissionFunction)
		{
			try
			{
				return await returningPermissionFunction();
			}
			catch (NullPermissionException nullPermissionException)
			{
				throw CreateAndLogValidationException(nullPermissionException);
			}
			catch (InvalidPermissionException invalidPermissionException)
			{
				throw CreateAndLogValidationException(invalidPermissionException);
			}
			catch (NotFoundPermissionException notFoundPermissionException)
			{
				throw CreateAndLogValidationException(notFoundPermissionException);
			}
			catch (PostgresException postgresException)
			{
				var failedPermissionStorageException =
					new FailedPermissionStorageException(postgresException);

				throw CreateAndLogFatalDependencyException(failedPermissionStorageException);
			}
			catch (DbUpdateException dbUpdateException)
			{
				var failedPermissionStorageException =
					new FailedPermissionStorageException(dbUpdateException);

				throw CreateAndLogFatalDependencyException(failedPermissionStorageException);
			}
			catch (Exception serviceException)
			{
				var failedPermissionServiceException =
					new FailedPermissionServiceException(serviceException);

				throw CreateAndLogServiceException(failedPermissionServiceException);
			}
		}

		public static IQueryable<GetAllPermissionDto> TryCatch(ReturningPermissionsFunction returningPermissionsFunction)
		{
			try
			{
				return returningPermissionsFunction().AsQueryable();
			}
			catch (PostgresException postgresException)
			{
				var failedPermissionStorageException =
					new FailedPermissionStorageException(postgresException);

				throw CreateAndLogFatalDependencyException(failedPermissionStorageException);
			}
			catch (Exception serviceException)
			{
				var failedPermissionServiceException =
					new FailedPermissionServiceException(serviceException);

				throw CreateAndLogServiceException(failedPermissionServiceException);
			}
		}

		private static PermissionServiceException CreateAndLogServiceException(Exception exception)
		{
			var permissionServiceException = new PermissionServiceException(exception);
			Log.Error(permissionServiceException, exception.Message);

			return permissionServiceException;
		}

		private static PermissionValidationException CreateAndLogValidationException(Xeption exception)
		{
			var permissionValidationException = new PermissionValidationException(exception);
			Log.Error(permissionValidationException, exception.Message);

			return permissionValidationException;
		}

		private static PermissionDependencyException CreateAndLogFatalDependencyException(Xeption exception)
		{
			var permissionDependencyException = new PermissionDependencyException(exception);
			Log.Fatal(permissionDependencyException, exception.Message);

			return permissionDependencyException;
		}
	}
}
