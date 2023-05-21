//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Xeptions;

namespace Taskify.Application.UseCases.Permissions.Exceptions
{
	public class PermissionDependencyValidationException : Xeption
	{
        public PermissionDependencyValidationException(Xeption innerException)
            : base(message: "Team dependency validation error occurred, fix the errors and try again.", innerException) { }
    }
}
