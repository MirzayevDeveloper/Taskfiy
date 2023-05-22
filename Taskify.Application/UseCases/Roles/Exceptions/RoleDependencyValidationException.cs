//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Xeptions;

namespace Taskify.Application.UseCases.Roles.Exceptions
{
	public class RoleDependencyValidationException : Xeption
	{
		public RoleDependencyValidationException(Xeption innerException)
			: base(message: "Role dependency validation error occurred, fix the errors and try again.", innerException) { }

	}
}
