//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using Xeptions;

namespace Taskify.Application.UseCases.Roles.Exceptions
{
	public class AlreadyExistsRoleException : Xeption
	{
		public AlreadyExistsRoleException(Exception innerException)
			: base(message: "Role already exists.", innerException) { }
	}
}
