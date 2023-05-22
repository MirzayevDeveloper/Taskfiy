//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Xeptions;

namespace Taskify.Application.UseCases.Roles.Exceptions
{
	public class RoleValidationException : Xeption
	{
		public RoleValidationException(Xeption innerException)
			: base(message: "Role validation error occurred, fix the errors and try again!.", innerException)
		{ }
	}
}
