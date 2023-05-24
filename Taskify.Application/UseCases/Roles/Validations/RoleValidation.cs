//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taskify.Application.Abstractions;
using Taskify.Application.UseCases.Permissions.Exceptions;
using Taskify.Application.UseCases.Roles.Exceptions;
using Taskify.Application.UseCases.Roles.Models;
using Taskify.Domain.Models.Roles;

namespace Taskify.Application.UseCases.Roles.Validations
{
	public class RoleValidation
	{
		private static IApplicationDbContext _context;

		public RoleValidation(IApplicationDbContext context)
		{
			_context = context;
		}

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

		public static async ValueTask<List<RolePermission>> ValidateRolePermissions(RoleDto dto, Guid roleId)
		{
			List<Permission> permissions =
				await _context.GetAll<Permission>().ToListAsync();

			bool allExists = dto.Permissions.All(
				per => permissions.Any(p => p.PermissionName.Equals(per)));

			if (dto.Permissions is null) return null;

			var rolePermissions = new List<RolePermission>();

			foreach (string per in dto.Permissions)
			{
				Permission maybePermission =
					permissions.Find(x => x.PermissionName.Equals(per));

				if (maybePermission is null)
				{
					Role maybeRole = await _context.GetAsync<Role>(roleId);
					await _context.DeleteAsync<Role>(maybeRole);
					throw new NotFoundPermissionException(per);
				}

				rolePermissions.Add(new() 
				{
					PermissionId = maybePermission.Id,
					RoleId = roleId
				});
			}

			return rolePermissions;
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
