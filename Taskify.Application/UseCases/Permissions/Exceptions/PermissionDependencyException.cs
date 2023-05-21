//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Xeptions;

namespace Taskify.Application.UseCases.Permissions.Exceptions
{
	public class PermissionDependencyException : Xeption
	{
		public PermissionDependencyException(Xeption innerException)
			: base(message: "Permission dependency error occurred, contact support.", innerException)
		{ }
	}
}
