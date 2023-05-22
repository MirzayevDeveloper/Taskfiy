//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using Taskify.Application.UseCases.Roles.Exceptions;
using Taskify.Domain.Models.Roles;

namespace Taskify.Application.UseCases.Roles.Validations
{
	public class RoleValidation
	{
		public static void ValidateRoleOnCreate(Role role)
		{
			ValidateRoleIsNotNull(role);

			Validate(
				(Rule: IsInvalid(role.RoleName), Parameter: nameof(Role.RoleName)));
		}

		public static void ValidateRoleOnUpdate(Role role)
		{
			ValidateRoleIsNotNull(role);

			Validate(
				(Rule: IsInvalid(role.Id), Parameter: nameof(Role.Id)),
				(Rule: IsInvalid(role.RoleName), Parameter: nameof(Role.RoleName)));
		}

		public static void ValidateRoleId(Guid roleId)
		{
			Validate((Rule: IsInvalid(roleId), Parameter: nameof(Role.Id)));
		}

		public static void ValidateRoleExists(Role role, Guid roleId)
		{
			if (role == null)
			{
				throw new NotFoundRoleException(roleId);
			}
		}

		private static dynamic IsInvalid(string text) => new
		{
			Condition = string.IsNullOrWhiteSpace(text),
			Message = "Text is required"
		};

		private static dynamic IsInvalid(Guid Id) => new
		{
			Condition = Id == default,
			Message = "Text is required"
		};

		private static void ValidateRoleIsNotNull(Role role)
		{
			if (role is null)
			{
				throw new NullRoleException();
			}
		}

		private static void Validate(params (dynamic Rule, string Parameter)[] validations)
		{
			var invalidRoleException = new InvalidRoleException();

			foreach ((dynamic rule, string parameter) in validations)
			{
				if (rule.Condition)
				{
					invalidRoleException.UpsertDataList(
						key: parameter,
						value: rule.Message);
				}
			}

			invalidRoleException.ThrowIfContainsErrors();
		}
	}
}
