//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using Taskify.Application.UseCases.Permissions.Exceptions;
using Taskify.Domain.Models.Roles;

namespace Taskify.Application.UseCases.Permissions.Validation
{
	public class PermissionValidation
	{
		public static void ValidatePermissionOnCreate(Permission permission)
		{
			ValidatePermissionIsNotNull(permission);

			Validate(
				(Rule: IsInvalid(permission.PermissionName), Parameter: nameof(Permission.PermissionName)));
		}

		public static void ValidatePermissionOnUpdate(Permission permission)
		{
			ValidatePermissionIsNotNull(permission);

			Validate(
				(Rule: IsInvalid(permission.PermissionName), Parameter: nameof(Permission.PermissionName)),
				(Rule: IsInvalid(permission.Id), Parameter: nameof(Permission.Id)));
		}

		public static void ValidatePermissionExists(Permission maybePermission, Guid permissionId)
		{
			if (maybePermission == null)
			{
				throw new NotFoundPermissionException(permissionId);
			}
		}

		public static void ValidatePermissionId(Guid permissionId)
		{
			Validate(
				(Rule: IsInvalid(permissionId), Parameter: nameof(Permission.Id)));
		}

		private static dynamic IsInvalid(Guid id) => new
		{
			Condition = id == default,
			Message = "Id is required"
		};

		private static dynamic IsInvalid(string text) => new
		{
			Condition = string.IsNullOrWhiteSpace(text),
			Message = "Text is required"
		};

		private static void ValidatePermissionIsNotNull(Permission permission)
		{
			if (permission is null)
			{
				throw new NullPermissionException();
			}
		}

		private static void Validate(params (dynamic Rule, string Parameter)[] validations)
		{
			var invalidPermissionException = new InvalidPermissionException();

			foreach ((dynamic rule, string parameter) in validations)
			{
				if (rule.Condition)
				{
					invalidPermissionException.UpsertDataList(
						key: parameter,
						value: rule.Message);
				}
			}

			invalidPermissionException.ThrowIfContainsErrors();
		}
	}
}
