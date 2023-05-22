//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using Xeptions;

namespace Taskify.Application.UseCases.Roles.Exceptions
{
	public class RoleServiceException : Xeption
	{
		public RoleServiceException(Exception innerException)
			: base(message: "Role service error occurred, contact support.", innerException)
		{ }
	}
}
