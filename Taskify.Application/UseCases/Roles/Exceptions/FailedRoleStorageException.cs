//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using Xeptions;

namespace Taskify.Application.UseCases.Roles.Exceptions
{
	public class FailedRoleStorageException : Xeption
	{
		public FailedRoleStorageException(Exception innerException)
			: base(message: "Failed role storage error occurred, contact support.", innerException) { }

	}
}
