//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using Xeptions;

namespace Taskify.Application.UseCases.Roles.Exceptions
{
	public class NotFoundRoleException : Xeption
	{
		public NotFoundRoleException(Guid roleId)
			: base(message: $"Couldn't find role with id: {roleId}.")
		{ }
	}
}
