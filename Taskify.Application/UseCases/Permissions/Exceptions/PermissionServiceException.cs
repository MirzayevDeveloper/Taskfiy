//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using Xeptions;

namespace Taskify.Application.UseCases.Permissions.Exceptions
{
	public class PermissionServiceException : Xeption
	{
		public PermissionServiceException(Exception innerException)
			: base(message: "Permission service error occurred, contact support.", innerException)
		{ }
	}
}
