//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using Xeptions;

namespace Taskify.Application.UseCases.Permissions.Exceptions
{
	public class AlreadyExistsPermissionException : Xeption
	{
		public AlreadyExistsPermissionException(Exception innerException)
			: base(message: "Permission already exists.", innerException) { }
	}
}
