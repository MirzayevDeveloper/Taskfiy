//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Xeptions;

namespace Taskify.Application.UseCases.Roles.Exceptions
{
	public class RoleDependencyException : Xeption
	{
		public RoleDependencyException(Xeption innerException)
			: base(message: "Role dependency error occurred, contact support.", innerException)
		{ }
	}
}
