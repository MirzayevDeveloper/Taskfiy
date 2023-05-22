//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Xeptions;

namespace Taskify.Application.UseCases.Roles.Exceptions
{
	public class InvalidRoleException : Xeption
	{
		public InvalidRoleException()
			: base("Role is invalid.")
		{ }
	}
}
