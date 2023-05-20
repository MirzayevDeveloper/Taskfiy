//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Xeptions;

namespace Taskify.Application.UseCases.Permissions.Exceptions
{
	public class PermissionValidationException : Xeption
	{
		public PermissionValidationException(Xeption innerException)
			: base(message: "Permission validation error occured, fix the erros and try again!.", innerException)
		{ }
	}
}
