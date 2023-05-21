//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using Xeptions;

namespace Taskify.Application.UseCases.Permissions.Exceptions
{
	public class FailedPermissionServiceException : Xeption
	{
		public FailedPermissionServiceException(Exception innerException)
			: base(message: "Failed permission service error occurred, please contact support.",
				innerException)
		{ }
	}
}
