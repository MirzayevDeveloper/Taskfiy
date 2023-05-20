﻿//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using Xeptions;

namespace Taskify.Application.UseCases.Permissions.Exceptions
{
	public class NotFoundPermissionException : Xeption
	{
		public NotFoundPermissionException(Guid permissionId)
			: base(message: $"Couldn't find team with id: {permissionId}.")
		{ }
	}
}
