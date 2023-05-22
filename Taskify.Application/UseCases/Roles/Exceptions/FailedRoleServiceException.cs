//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using Xeptions;

namespace Taskify.Application.UseCases.Roles.Exceptions
{
	public class FailedRoleServiceException : Xeption
	{
		public FailedRoleServiceException(Exception innerException)
			: base(message: "Failed role service error occurred, please contact support.",
				innerException)
		{ }
	}
}
