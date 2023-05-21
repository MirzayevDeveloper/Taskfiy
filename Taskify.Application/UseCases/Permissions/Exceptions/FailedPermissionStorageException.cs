//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using Xeptions;

namespace Taskify.Application.UseCases.Permissions.Exceptions
{
	public class FailedPermissionStorageException : Xeption
	{
		public FailedPermissionStorageException(Exception innerException)
			: base(message: "Failed permission storage error occurred, contact support.", innerException) { }
	}
}
