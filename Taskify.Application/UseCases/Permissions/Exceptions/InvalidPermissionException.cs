//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Xeptions;

namespace Taskify.Application.UseCases.Permissions.Exceptions
{
	public class InvalidPermissionException : Xeption
	{
		public InvalidPermissionException()
			: base("Permission is invalid.")
		{ }
	}
}
